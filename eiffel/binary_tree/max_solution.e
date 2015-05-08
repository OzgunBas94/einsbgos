note
	description: "Summary description for {MAX_SOLUTION}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

class
	MAX_SOLUTION
	inherit SOLUTION

create
	make

feature {MAX_PROBLEM} --initialization

	make(new_value: INTEGER)
		do
			set(new_value)
		end

feature {NONE}

	value: INTEGER

feature {MAX_PROBLEM}

	set(new_value: INTEGER)
		do
			value:= new_value
		end


end
