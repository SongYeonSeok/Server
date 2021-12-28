install.packages('dplyr')
library(dplyr)

dir <- choose.dir()
setwd(dir)
temp_data <- read.table('온도.txt', sep = '\t', header = T, fileEncoding = "utf-8")
moist_data <- read.table('습도.txt', sep='\t', header = T, fileEncoding = "utf-8")
View(temp_data)
View(moist_data)


n1 <- length(temp_data$temp)
n2 <- length(moist_data$moist)
print(n1)
print(n2)

temp_11 <- temp_data %>% filter(t1 == 1 & t2 == 1)
temp_10 <- temp_data %>% filter(t1 == 1 & t2 == -1)
temp_01 <- temp_data %>% filter(t1 == -1 & t2 == 1)
temp_00 <- temp_data %>% filter(t1 == -1 & t2 == -1)

temp_correct_vec <- c(length(temp_11$temp), length(temp_10$temp),
				length(temp_01$temp), length(temp_00$temp))

moist_11 <- moist_data %>% filter(t1 == 1 & t2 == 1)
moist_10 <- moist_data %>% filter(t1 == 1 & t2 == -1)
moist_01 <- moist_data %>% filter(t1 == -1 & t2 == 1)
moist_00 <- moist_data %>% filter(t1 == -1 & t2 == -1)

moist_correct_vec <- c(length(moist_11$moist), length(moist_10$moist),
				length(moist_01$moist), length(moist_00$moist))

temp_111 <- temp_11 %>% filter(temp <= 20 | temp >= 30)
temp_011 <- temp_11 %>% filter(temp > 20 & temp < 30)

temp_correct2_vec <- c(length(temp_111$temp), length(temp_011$temp))

moist_111 <- moist_11 %>% filter(moist <= 40 | moist >= 55)
moist_011 <- moist_11 %>% filter(moist > 40 & moist < 55)

moist_correct2_vec <- c(length(moist_111$moist), length(moist_011$moist))
