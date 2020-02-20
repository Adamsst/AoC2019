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
	var tempProgram = make([]int, len(program))
	copy(tempProgram, program)

	for tracker < len(tempProgram) {
		tempProgram, tracker = processOpCode(tempProgram, tracker)
	}

	fmt.Println("P1: ", tempProgram[0]) //P1 answer

	var finished = false
	var noun = 0
	var verb = 0

	for finished == false {
		copy(tempProgram, program)
		tracker = 0
		tempProgram[1] = noun
		tempProgram[2] = verb

		for tracker < len(tempProgram) {
			tempProgram, tracker = processOpCode(tempProgram, tracker)
		}

		if tempProgram[0] == 19690720 {
			finished = true
		} else {
			noun++
			if noun == 100 {
				noun = 0
				verb++
			}
		}
	}

	fmt.Println("P2: ", (100*noun)+verb) //P2 answer
}

//getInput uses a filepath string parameter to read a files contents into a string and then return those contents as a slice after delimiting by comma
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

	switch {
	case p[t] == 1:
		p[p[t+3]] = p[p[t+1]] + p[p[t+2]]
		t += 3
	case p[t] == 2:
		p[p[t+3]] = p[p[t+1]] * p[p[t+2]]
		t += 3
	default:
		t = len(p)
	}

	t++

	return p, t
}