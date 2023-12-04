from PIL import Image, ImageDraw, ImageFont
import boto3
from pprint import pprint, pformat
from io import BytesIO
from image_helpers import get_image


# --------------------------------------------------------------------
# DO NOT CHANGE THESE FUNCTIONS


def format_text(text, columns):
    """
    Returns a copy of text that will not span more than the specified number of columns
    :param text: the text
    :param columns: the maximum number of columns
    :return: the formatted text
    """
    # format the text to fit the specified columns
    import re
    text = re.sub('[()\']', '', pformat(text, width=columns))
    text = re.sub('\n ', '\n', text)
    return text


def text_rect_size(text, font, draw=None):
    """
    Returns the size of the rectangle to be used to
    draw as the background for the text
    :param text: the text to be displayed
    :param font: the font to be used
    :param draw: an ImageDraw.Draw object
    :return: the size of the rectangle to be used to draw as the background for the text
    """
    if draw is None:
        dummy_img = Image.new('RGB', (0, 0), (255, 255, 255, 0))
        draw = ImageDraw.Draw(dummy_img)
        (width, height) = draw.multiline_textsize(text, font=font)
        del draw
    else:
        (width, height) = draw.multiline_textsize(text, font=font)
    return width * 1.1, height * 1.3


def add_text_to_img(img, text, pos=(0, 0), color=(255, 255, 255), bgcolor=(255, 255, 255, 128),
                    columns=60,
                    font=ImageFont.truetype('ariblk.ttf', 22)):
    """
    Creates and returns a copy of the image with the specified text displayed on it
    :param img: the (Pillow) image
    :param text: the text to display
    :param pos: a 2 tuple containing the xpos, and ypos of the text
    :param color: the fill color of the text
    :param bgcolor: the background color of the box behind the text
    :param columns: the max number of columns for the text
    :param font: the font to use
    :return: a copy of the image with the specified text displayed on it
    """

    # make a blank image for the text, initialized to transparent text color
    txt_img = Image.new('RGBA', img.size, (255, 255, 255, 0))
    draw = ImageDraw.Draw(txt_img)

    # format the text
    text = format_text(text, columns)
    # get the size of the text drawn in the specified font
    (text_width, text_height) = ImageDraw.Draw(img).multiline_textsize(text, font=font)

    # compute positions and box size
    (xpos, ypos) = pos
    rwidth = text_width * 1.1
    rheight = text_height * 1.4
    text_xpos = xpos + (rwidth - text_width) / 2
    text_ypos = ypos + (rheight - text_height) / 2

    # draw the rectangle (slightly larger) than the text
    draw.rectangle([xpos, ypos, xpos + rwidth, ypos + rheight], fill=bgcolor)

    # draw the text on top of the rectangle
    draw.multiline_text((text_xpos, text_ypos), text, font=font, fill=color)

    del draw  # clean up the ImageDraw object
    return Image.alpha_composite(img.convert('RGBA'), txt_img)


def get_pillow_img(imgbytes):
    """
    Creates and returns a Pillow image from the given image bytes
    :param imgbytes: the bytes of the image
    """
    return Image.open(BytesIO(imgbytes))


# END DO NOT CHANGE SECTION
# --------------------------------------------------------------------


def search_label(name, labels):
    for label in labels:
        if label['Name'] == name:
            return True
    return False


def label_image(img, confidence=50):
    """
    Creates and returns a copy of the image, with labels from Rekognition displayed on it
    :param img: a string that is either the URL or filename for the image
    :param confidence: the confidence level (defaults to 50)

    :return: a copy of the image, with labels from Rekognition displayed on it
    """

    rekognition = boto3.client('rekognition', region_name='us-east-1')
    imgbytes = get_image(img)
    response = rekognition.detect_labels(
        Image={'Bytes': imgbytes},
        MinConfidence=confidence)

    text = 'Not Food'
    background = (0, 0, 200, 255)

    if search_label('Food', response['Labels']):
        if search_label('Hot Dog', response['Labels']):
            text = 'Hot Dog'
            background = (0, 200, 0, 255)
        else:
            text = 'Not Hot Dog'
            background = (200, 0, 0, 255)

    pillow_img = get_pillow_img(imgbytes)

    return add_text_to_img(pillow_img, text, bgcolor=background)


if __name__ == "__main__":
    # can't use input since PyCharm's console causes problems entering URLs
    # img = input('Enter either a URL or filename for an image: ')
    # img = 'https://render.fineartamerica.com/images/rendered/default/poster/8/10/break/images/artworkimages/medium/1/pizza-slice-diane-diederich.jpg'
    img = 'https://i.kinja-img.com/gawker-media/image/upload/s--6RyJpgBM--/c_scale,f_auto,fl_progressive,q_80,w_800/tmlwln8revg44xz4f0tj.jpg'

    labelled_image = label_image(img)
    labelled_image.show()
