
package main

import (
"bufio"
"fmt"
"log"
"os"
"strconv"
"strings"
)

func main() {
var program = getInput("input.txt")
var tracker = 0

for tracker < len(program) {
	program, tracker = processOpCode(program, tracker)
}

}

//getInput uses a filepath string parameter to read a file's contents into a string and then return those contents as a slice after delimiting by comma
//The returned slice has element of type int after converting each element from a string
func getInput(filePath string) []int {
var s string
file, err := os.Open(filePath)
if err != nil {
	log.Fatal(err)
}
defer file.Close()

scanner := bufio.NewScanner(file)
for scanner.Scan() {
	s = scanner.Text()
}

if err := scanner.Err(); err != nil {
	log.Fatal(err)
}

var input []string = strings.Split(s, ",")
var intInput = make([]int, len(input))

for i := 0; i < len(intInput); i++ {
	intInput[i], err = strconv.Atoi(input[i])
}

return intInput
}

//processOpCode takes an int slice and an index and processes the opcode found at the index of the slice
func processOpCode(p []int, t int) ([]int, int) {

var operation []int
var opCodeInt int

operation, opCodeInt = getOpCodeParams(p[t])

switch opCodeInt {
case 1, 2, 7, 8:

var p1 int
var p2 int
var p3 int
	
if operation[2] == 0 {
	p1 = p[p[t+1]]
} else {
	p1 = p[t+1]
}

if operation[1] == 0 {
	p2 = p[p[t+2]]
} else {
	p2 = p[t+2]
}

if opCodeInt == 1 {
	p3 = p1 + p2
} else if opCodeInt == 2 {
	p3 = p1 * p2
} else if opCodeInt == 7 {
	if p1 < p2 {
		p3 = 1
	} else {
		p3 = 0
	}
} else if opCodeInt == 8 {
	if p1 == p2 {
		p3 = 1
	} else {
		p3 = 0
	}
}

if operation[0] == 0 {
	p[p[t+3]] = p3
} else {
	p[t+3] = p3
	fmt.Println("processOpCode Case 1,2, I dont think we should ever be here")
}

t += 3
case 3:
//Take an input and store it at t+1
fmt.Print("OpCode 3: ")
var i int
fmt.Scan(&i)
p[p[t+1]] = i
t++
case 4:
//Output the value stored at t+1
fmt.Print("OpCode 4: ")
fmt.Println(p[p[t+1]])
t++
case 5, 6:
var p1 int
var p2 int

if operation[2] == 0 {
	p1 = p[p[t+1]]
} else {
	p1 = p[t+1]
}

if operation[1] == 0 {
	p2 = p[p[t+2]]
} else {
	p2 = p[t+2]
}

if opCodeInt == 5 {
	if p1 != 0 {
		t = p2 - 1
	} else {
		t += 2
	}
} else if opCodeInt == 6 {
	if p1 == 0 {
		t = p2 - 1
	} else {
		t += 2
	}
}

case 99:
fmt.Println("Ninety-Nine!")
t = len(p)
default:
fmt.Println("Error!")
t = len(p)
}

t++

return p, t
}

//GetOpCodeParams takes an integer and returns the operation code as well as a slice of necessary parameters according to the operation code
func getOpCodeParams(input int) ([]int, int) {
var opCodeString = strconv.Itoa(input)
var opCodeInt int
var err error

if input == 3 || input == 4 || input == 99 {
	opCodeInt = input
} else {
	for len(opCodeString) < 5 {
		opCodeString = "0" + opCodeString
	}
	opCodeInt, err = strconv.Atoi(opCodeString[len(opCodeString)-2:])
	
	if err != nil {
		fmt.Println(err)
	}
}

operation := []int{}

switch opCodeInt {
case 1, 2, 5, 6, 7, 8: //ToDo: I think 5 6 7 8 actually go here
for i := 0; i < len(opCodeString)-2; i++ {
newInt, err := strconv.Atoi(opCodeString[i : i+1])
if err == nil {
	operation = append(operation, newInt)
}
}
case 3:
fmt.Println("Case 3 GetOpCodeParams!")
case 4:
fmt.Println("Case 4 GetOpCodeParams!")
default:
fmt.Print(opCodeInt)
fmt.Println(" Default Case GetOpCodeParams!")
}

return operation, opCodeInt
}