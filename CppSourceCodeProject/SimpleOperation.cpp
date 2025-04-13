#include "pch.h"
#include "SimpleOperation.h"

int SimpleOperation::SumInts(int* intArray) {
	// Sum the elements of the array pointed to by p
	int sum = 0;
	//int* intArray = static_cast<int*>(p);
	while (*intArray != 0) {
		sum += *intArray;
		intArray++;
	}
	return sum;
}
extern "C" __declspec(dllexport) int SumInts(int* p)
{
	return SimpleOperation::SumInts(p);
}