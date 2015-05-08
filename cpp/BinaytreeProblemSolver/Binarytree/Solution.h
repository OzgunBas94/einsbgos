#pragma once


 class Solution
{

protected:
	Solution*solution;
	virtual void Solution::setSolution(Solution* solution) {
		this->solution = solution;
	}
public:
	virtual Solution*Solution::getSolution() const{
		return solution;
	}


};