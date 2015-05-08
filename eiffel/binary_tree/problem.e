note
	description: "Summary description for {PROBLEM}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

deferred class
	PROBLEM

feature {NONE}
	sol: SOLUTION

feature {ANY} --Getters

	get_solution: SOLUTION
				--Returns solution for 'Current'
		require
			valid_solution
		deferred
		end

	valid_solution: BOOLEAN
				--Returns true if problem has right solution
		require
			values_correct
		deferred
		end

	values_correct: BOOLEAN
				--checks if all values are correct
		require
			current/=void
		deferred
		end

feature --Problemsolving

	solve
		require
			values_correct
		deferred
		ensure
			valid_solution
		end


end
