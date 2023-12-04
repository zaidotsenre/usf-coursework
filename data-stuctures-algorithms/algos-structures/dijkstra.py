import re
import stack
import bitree
import typing


def is_num(s):
    """
    Returns True if and only if s can be parsed as an integer
    :param s: the string to test
    :return: True if and only if s can be parsed as an integer
    DO NOT CHANGE THIS CODE!
    """
    try:
        int(s)
        return True
    except ValueError:
        return False


def to_num(s: str):
    """
    If s can be parsed as an integer, return the result of the parse,
    otherwise, return s without conversion
    :param s: the string to try to convert to a number
    :return: if s can be parsed as an integer, return the result of the parse,
             otherwise, return s without conversion
    DO NOT CHANGE THIS CODE!
    """
    try:
        return int(s)
    except ValueError:
        return s


def tokenize(exp: str) -> typing.List:
    """
    Breaks a math expression up into a list of its parts, separates the numbers from the operators
    NOTE: Numbers strings in exp that are numbers should be returned as numbers,
          the code currently does not do this, you must modify it to do so.
    :param exp: the math expression to tokenize
    :return: a (Python) list of the parts that make up the expression

    >>> tokenize('3 + -4 * 5')
    [3, '+', -4, '*', 5]
    >>> tokenize('(3 + -4) * 5')
    ['(', 3, '+', -4, ')', '*', 5]
    """
    # TODO: modify the code below to meet the spec
    tokens = [to_num(t.strip()) for t in re.split(r'((?:-?\d+)|[+\-*/()])', exp)]
    return [t for t in tokens if t != '']


def is_op(s):
    """
    Returns True iff s is an operator
    :param s: the string to test
    :return: True iff s is an operator, and False, otherwise
    DO NOT CHANGE THIS CODE!

    >>> is_op('+')
    True
    >>> is_op('-')
    True
    >>> is_op('*')
    True
    >>> is_op('/')
    True
    >>> import random
    >>> ascii = ord('+')
    >>> while chr(ascii) in '+-*/':
    ...     ascii = random.randint(0, 255)
    >>> is_op(chr(ascii))
    False
    """
    return str(s) in '+-*/'


def precedence(op: str):
    """
    Returns the precedence value of the specified operator
    :param op: the operator
    :return: the precedence value of the specified operator,
             and False, if it is not one of the four
    DO NOT CHANGE THIS CODE!
    """
    precs = {
        '+': 2,
        '-': 2,
        '*': 3,
        '/': 3
    }
    return precs.get(op, False)


def to_rpn(expr: str):
    """
    Convert the given infix math expression to Reverse Polish Notation (postfix)
    Refer to https://en.wikipedia.org/wiki/Shunting-yard_algorithm#The_algorithm_in_detail
    for the algorithm details
    :param expr: an infix math expression
    :return: the Reverse Polish Notation version of the infix expression

    >>> to_rpn('3 * -4 + 5')
    '3 -4 * 5 + '
    >>> to_rpn('3 + -4 * 5')
    '3 -4 5 * + '
    >>> to_rpn('(3 + -4) * 5')
    '3 -4 + 5 * '
    """
    # TODO: replace pass below with your implementation
    tokens = tokenize(expr)
    op_stack = stack.LRStack()
    output_queue = []

    for token in tokens:
        if is_num(token):
            output_queue.append(token)
        elif is_op(token):
            while (not op_stack.is_empty()) and op_stack.top() != '(' and precedence(op_stack.top()) >= precedence(token):
                output_queue.append(op_stack.pop())
            op_stack.push(token)
        elif token == "(":
            op_stack.push(token)
        elif token == ')':
            while op_stack.top() != '(':
                output_queue.append(op_stack.pop())
            op_stack.pop()

    while not op_stack.is_empty():
        output_queue.append(op_stack.pop())

    return f"{' '.join(str(x) for x in output_queue)} "


def to_ast(expr: str):
    r"""
    Converts the given infix expression to an AST
    :param expr: a string with an infix math expression
    :return: an abstract syntax tree of the expression
    DO NOT CHANGE THIS CODE!

    Based on
    https://softwareengineering.stackexchange.com/a/254075,
    and
    https://www.klittlepage.com/2013/12/22/twelve-days-2013-shunting-yard-algorithm/
    last access 11/20/2017

    >>> to_ast('3 + 4 * -5').execute(bitree.VerticalStringAlgo()) # doctest: +NORMALIZE_WHITESPACE
    '+\n|_ 3\n|  |_ []\n|  |_ []\n|_ *\n   |_ 4\n   |  |_ []\n   |  |_ []\n   |_ -5\n      |_ []\n      |_ []'
    >>> to_ast('(3 + -4) * 5').execute(bitree.VerticalStringAlgo()) # doctest: +NORMALIZE_WHITESPACE
    '*\n|_ +\n|  |_ 3\n|  |  |_ []\n|  |  |_ []\n|  |_ -4\n|     |_ []\n|     |_ []\n|_ 5\n   |_ []\n   |_ []'
    """

    def add_node(stack, op):
        """
        Helper function to pop two operands from operator_stack and
        :param stack:
        :param op:
        :return:
        DO NOT CHANGE THIS CODE!
        """
        right = stack.pop()
        left = stack.pop()
        stack.push(bitree.DataNode(op, left, right))

    operator_stack = stack.LRStack()
    operand_stack = stack.LRStack()
    toks = [to_num(t) for t in tokenize(expr)]
    for tok in toks:
        if is_num(tok):
            operand_stack.push(bitree.DataNode(tok))
        elif is_op(tok):
            while (not operator_stack.is_empty()) and precedence(operator_stack.top()) >= precedence(tok):
                add_node(operand_stack, operator_stack.pop())
            operator_stack.push(tok)
        elif tok == '(':
            operator_stack.push(tok)
        elif tok == ')':
            while (not operator_stack.is_empty()) and operator_stack.top() != '(':
                add_node(operand_stack, operator_stack.pop())
            if operator_stack.is_empty():
                print('Unbalanced parentheses')
                return None
            # else:
            operator_stack.pop()
    while not operator_stack.is_empty():
        add_node(operand_stack, operator_stack.pop())
    return operand_stack.pop()


def eval_rpn(expr: str):
    """
    Evaluates the Reverse Polish Notation expression
    :param expr: a string containing a Reverse Polish Notation expression
    :return: the result of evaluating the RPN expression

    Refer to the left-to-right algorithm at
    https://en.wikipedia.org/wiki/Reverse_Polish_notation#Postfix_evaluation_algorithm
    for the algorithm details

    >>> eval_rpn('3 -4 * 5 +')
    -7
    >>> eval_rpn('3 -4 5 * +')
    -17
    >>> eval_rpn('3 -4 + 5 * ')
    -5
    """
    # TODO: replace pass below with your implementation
    def eval_helper(a, b, op: str):
        if op == '+':
            return a + b
        if op == '-':
            return a - b
        if op == '*':
            return a * b
        if op == '/':
            return a / b

    value_stack = stack.LRStack()
    tokens = tokenize(expr)
    for token in tokens:
        if is_num(token):
            value_stack.push(token)
        elif is_op(token):
            right = value_stack.pop()
            left = value_stack.pop()
            value_stack.push(eval_helper(left, right, token))
    return value_stack.pop()


if __name__ == '__main__':
    # This is here for your own use
    pass
