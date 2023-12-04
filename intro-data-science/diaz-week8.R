# Function 1: Create a function called "readStates":

  #Step 1: Create a function (named readStates) to read a CSV file into R: 
  # within the Function 1

    #Q1. You need to read a URL, not a local file to your computer. 
    # The file is a dataset on state populations (within the United States).

  #Step 2: Clean the dataframe: within Function 1

    #Q2. Note the issues that need to be fixed (removing columns, removing rows, 
    # removing dots in front of the state names, changing column names).

    #Q3. Within your function, make sure there are 51 rows (one per state + 
    # the district of Columbia). Make sure there are only 5 columns with the 
    # columns having the following names 
    # (stateName, Census, Estimates, Pop2010, Pop2011).

    #Q4. Make sure the last four columns are numbers (i.e. not strings).

  readStates <- function(address){

    # Read the csv file    
    data <- read.csv(url(address), stringsAsFactors = FALSE)

    # Remove unnecessary rows and columns
    data <- data[-60:-66,]
    data <- data[-1:-8, -6:-10]
    
    # Rename the columns
    cnames <- c("stateName", "Census", "Estimates", "Pop2010", "Pop2011")
    colnames(data) <- cnames
    
    # Remove dots from state names
    data$stateName <- gsub("\\.", "", data[,1])

    # Convert strings to numerics
    data$Census <- as.numeric(gsub(",", "", data$Census))
    data$Estimates <- as.numeric(gsub(",", "", data$Estimates))
    data$Pop2010 <- as.numeric(gsub(",", "", data$Pop2010))
    data$Pop2011 <- as.numeric(gsub(",", "", data$Pop2011))
    
    # Reset row numbers
    rownames(data) <- NULL
    
    return(data)
    
  }


#Outside of Function 1

  #Step 3: Store and explore the dataset: outside of Function 1
  
    #Q5. Store the dataset into a dataframe, called dfStates.
    # When you run the following, it should print a clean dataframe. 
    # Please include the output of "dfStates" in the compiled file by 
    # running dfStates as below. 
    dfStates <- readStates("http://www2.census.gov/programs-surveys/popest/tables/2010-2011/state/totals/nst-est2011-01.csv")
    dfStates
  
    #Q6. Test your dataframe by calculating the mean for the 2011 data, 
    # by doing (include your output):
    # You should get an answer of  6,109,645  
    mean(dfStates$Pop2011)
    
  #Step 4: Find the state with the highest population: outside the Function 1
  
    #Q7. Based on the 2011 data, what is the population of the state with the 
    # highest population? What is the name of that state, and what is the value 
    # of the population?
    pop <- max(dfStates$Pop2011)
    state <- dfStates$stateName[which.max(dfStates$Pop2011)]
    paste("State with the highest population in 2011: ", state, pop)
    
    #Q8. Sort the data, in decreasing order, based on the 2011 data.
    dfStates <- dfStates[order(dfStates$Pop2011, decreasing = TRUE),]
    dfStates

    
    

# Function 2: Create a function called "Distribution"

    #Step 5: Explore the distribution of the states: 
    # You need to create a new function called "Distribution"
    
      #Q9. You will write a function to calculate percentage of states that have 
      # population that is lower than the average.  
      # The function (function name: "Distribution") takes two parameters. 
      # The first is a vector and the second is a number. 
      # For example, Distribution <- function(vector, number). 
      # This step is just a setup for the following instruction. 
      # The function will return the percentage of elements within the vector 
      # that is less than the number (i.e. cumulative distribution below the 
      # value provided). For example,  
      # (1) Think about this: You only keep the elements within the vector 
      # that are less than the number, and store the number of eligible elements 
      # into the variable "count". Populate XXXX to complete this line of code: 

      # count <- length(vector[XXXX])

      # (2) Then, you will calculate the percentage and return the results. 
      # Populate XXXX to complete this line of code:

      # return((count/XXXX) *100)

      # ****For example, if the vector had 5 elements (1,2,3,4,5), with 2 being 
      # the number passed into the function, the function will return 20 
      # (since 20% of the numbers--that is 1-- is below 2). 
      # Again, if you pass number 5, then the function should return 80, 
      # since 80% of the numbers--1,2,3, and 4 are below 5. Pass these 
      # numbers using your function and see if your function returns the 
      # correct values.

      # (3) Test the function with the vector “dfStates$Pop2011”, 
      # and the mean of “dfStates$Pop2011.” *** you should get 66.66667 as a 
      # result. There are many ways to write this function 
      # (described in point 10) – so please try to write multiple versions of 
      # this function – which do you think is the best?
      
      Distribution <- function(vector, number){
        count <- length(vector[vector < number])
        return(count / length(vector) * 100)
      }
      
      Distribution2 <- function(vector){
        count <- length(vector[vector < mean(vector)])
        return(count / length(vector) * 100)
      }
      
      Distribution(dfStates$Pop2011, mean(dfStates$Pop2011))