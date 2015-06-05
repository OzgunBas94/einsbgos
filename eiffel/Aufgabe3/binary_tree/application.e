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
			tree: BINARYTREE[INTEGER]
			tree2: AVL_TREE[INTEGER]
			temp: AVL_NODE[INTEGER]
		do
			--| Add your code here
			print("Binaaerbaum")
			print("%N")
			create tree.make
			tree.insert (8)
			tree.insert (4)
			tree.insert (11)
			tree.insert (2)

			print(tree.has (2))
			print("%N")
			print(tree.has (5))
			print("%N")

			tree.delete (2)
			print("%N")

			print(tree.has (2))
			print("%N")
			print("-----------------------------------------------------------------------------")
			print("%N")
			print("AVL Baum")
			print("%N")



			create tree2.make
			tree2.insert (8)
			tree2.insert (4)
			tree2.insert (1)

			print(tree2.attached_node (tree2.get_root).get_value)
			print("%N")
			temp := tree2.attached_node (tree2.get_root)
			print(tree2.attached_node (temp.get_left).get_value)
			print("  ")
			print(tree2.attached_node (temp.get_right).get_value)
--			tree2.insert (1)
--			tree2.insert (6)
--			tree2.insert (5)
			--tree2.insert (7)
--			print(tree2.attached_node(tree2.get_root.get_left).get_value)
			print("%N")
--			temp := tree2.attached_node(tree2.get_root.get_left)
--			print(tree2.attached_node(temp.get_left).get_value)
--			print("  ")
--			print(tree2.attached_node(temp.get_right).get_value)
--			print("%N")

			print(tree2.has (2))
			print("%N")
			--print(tree2.get_root.get_value)
			tree2.delete (1)
			print(tree2.has (1))
			print("%N")
			print(tree2.has (5))
			print("%N")

		end

end
