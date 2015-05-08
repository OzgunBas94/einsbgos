note
	description: "Summary description for {MAX_PROBLEM}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

class
	MAX_PROBLEM
	inherit
		PROBLEM
		redefine sol end


create
	make

feature

	make(some_tree: MY_TREE)
		do
			valid:= false
			tree:= some_tree
			create make(0)
			solve
		end

feature

	sol: MAX_SOLUTION
	tree: MY_TREE
	valid: BOOLEAN

feature --Getter, returns solution

	get_solution: MAX_SOLUTION
		do
			Result:= sol
		end

feature --Setter sets tree to work with

	set
		local
			tmp_value: INTEGER
		do
			sol.set(tmp_value)
			if values_correct then
				solve
			end
			ensure
				values_correct or not valid_solution

		end


feature --checks

	values_correct: BOOLEAN
					--checks if values are correct
		do
			if tree/= void then
				Result:= true
			else
				Result:= false
			end
		end

	valid_solution: BOOLEAN
					--returns true if problem has right solution
		do
			if sol/= void then
				valid:= true
			else
				valid:= false
			end
			Result:= valid
		end

feature --Problemsolving


	solve
		require else
			tree_not_empty: tree.get_empty
		local
			tmp_node: attached NODE
			tmp_value: INTEGER
		do
			from
				tmp_node:= tree.get_root
			until
				tmp_node.get_right=void
			loop
				tmp_node:= attached_node(tmp_node.get_right)
			end
			tmp_value:= tmp_node.get_value
			sol.set(tmp_value)
		ensure then
			valid_solution
		end

feature --check Attach

	attached_node(d_node: detachable NODE): attached NODE
					--returns an attached node
		do
			check attached d_node as a_node then
				Result:= a_node
			end
		end

end
