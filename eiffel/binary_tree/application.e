note
	description : "binary_tree application root class"
	date        : "$Date$"
	revision    : "$Revision$"

class
	APPLICATION

inherit
	ARGUMENTS

create
	make

feature {NONE} -- Initialization

	make
			-- Run application.
		local
			tree: MY_TREE
		do
			--| Add your code here
			create tree.make
			tree.insert (8)
			tree.insert (4)
			tree.insert (11)
			tree.insert (2)
			tree.insert (10)
			tree.insert (16)
			tree.insert (12)
			tree.insert (0)

			print(tree.has (2))
			print("%N")
			print(tree.has (5))
			print("%N")

			tree.delete (2)

			print(tree.has (2))

		end

end
