note
	description: "Summary description for {BINARYTREE}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

-- The class BinaryTree is generic
class
	BINARYTREE [G->COMPARABLE]

-- superclass of the BinaryTree is InterfaceTree and with redefine it overrites the methods
inherit
	INTERFACETREE[G] redefine insert, delete, has end

create
	make

feature
	--Attribute: It's private
	root: detachable NODE [G] assign set_root

	-- Constructor with a value that is generic
	make (value: G)
		do
			create root.make (value)
			create filter_array.make_empty()
			create array.make_empty()
			output := ""
		end

	-- In this method you can insert a new node within a new value
	insert (val: G)
		do
			if root /= Void then
				insert_recursion (val, get_root)
			else
				create root.make (val)
			end
		end

	-- In this method it compares the values with each other.
    -- If the new value is higher than the current value, so it will look on the right of the binarytree and so on.
	insert_recursion (val: G; n: detachable NODE [G])
		local
			new_node: NODE [G]
		do
			if attached n as n_tmp then -- attached -> if n is not Null
				if val.three_way_comparison(n_tmp.value)>=0 then
					if n_tmp.right = Void then
						create new_node.make (val)
						n_tmp.right := new_node
						new_node.parent := n_tmp
					else
						insert_recursion (val, n_tmp.right)
					end
				end
				if val.three_way_comparison(n_tmp.value)=-1 then
					if n_tmp.left = Void then
						create new_node.make (val)
						n_tmp.left := new_node
						new_node.parent := n_tmp
					else
						insert_recursion (val, n_tmp.left)
					end
				end
			end
		end --insert_recursion

	-- The method returns a boolean. It returns true if the parameter value is in the tree.
	has (val: G): BOOLEAN
		do
			if root /= void then
				has_recursion (val, get_root)
				Result := has_bool
			else
				Result := False
			end
		end --has

	-- This method searches for the parameter value. The data type of currentNode is Node.
    -- The data type of value is int. It returns a boolean variable. It returns true when the value is in the tree.
	has_recursion (val: G; n: detachable NODE [G])
			do
			if attached n as n_tmp then
				if val = n_tmp.value then
					has_bool := True

				else
					if val.three_way_comparison(n_tmp.value)=1 and n_tmp.right /= Void then
						has_recursion (val, n_tmp.right)
					else
						if val.three_way_comparison(n_tmp.value)=-1 and n_tmp.left /= Void then
							has_recursion (val, n_tmp.left)
						else
							has_bool := False
						end
					end
				end
			end
		end --has_recursion

	-- In this method you can remove the desired node.
	delete (val: G)
		do
			if root /= Void then
				delete_recursion (val, get_root)
				if has (val) then
					delete (val)
				end
			end
		end --delete

	-- In this method it compares the values with each other.
    -- If the new value is higher than the current value, so it will look on the right of the binarytree and so on.
	delete_recursion (val: G; n: detachable NODE [G])
		do
			if attached n as n_tmp then
				if val = n_tmp.value and n_tmp.left = Void and n_tmp.right = Void and n_tmp.parent /= Void then
					del_no_child (n_tmp)
				else
					if val = n_tmp.value and n_tmp.left = Void and n_tmp.right /= Void and n_tmp.parent /= Void then
						del_one_child (n_tmp, True)
					else
						if val = n_tmp.value and n_tmp.left /= Void and n_tmp.right = Void and n_tmp.parent /= Void then
							del_one_child (n_tmp, False)
						else
							if val = n_tmp.value and n_tmp.left /= Void and n_tmp.right /= Void then
								del_two_children (n_tmp)
							else
								if val = n_tmp.value and n_tmp = root then
									if n_tmp.left = Void and n_tmp.right = Void then
										root := Void
									else
										if n_tmp.left /= Void and n_tmp.right = Void then
											n_tmp.get_left.set_parent (Void)
											root := n_tmp.left
										else
											if n_tmp.left = Void and n_tmp.right /= Void then
												n_tmp.get_right.set_parent (Void)
												root := n_tmp.right
											end
										end
									end
								end
							end
						end
					end
				end
				if val.three_way_comparison(n_tmp.value)=-1 then
					delete_recursion (val, n_tmp.left)
				else
					if val.three_way_comparison(n_tmp.value)=1 then
						delete_recursion (val, n_tmp.right)
					end
				end
			end
		end

	-- Delete a leaf of the binarytree
	del_no_child (n: NODE [G])
		do
			if n = n.get_parent.get_left then
				n.get_parent.left := Void
				n.parent := Void
			else
				n.get_parent.right := Void
				n.parent := Void
			end
		end

	del_one_child (n: NODE [G]; has_right: BOOLEAN)
		do
			if has_right then
				if n.get_parent.right = n then
					n.get_right.parent := n.get_parent
					n.get_parent.right := n.right
				else
					n.get_right.parent := n.get_parent
					n.get_parent.left := n.right
				end
			else
				if n.get_parent.right = n then
					n.get_left.parent := n.get_parent
					n.get_parent.right := n.left
				else
					n.get_left.parent := n.get_parent
					n.get_parent.left := n.left
				end
			end
		end

	del_two_children (n: NODE [G])
		local
			n_smallest: NODE [G]
		do
			n_smallest := get_smallest (n.get_right)
			n.value := n_smallest.value
			if n_smallest.left = Void and n_smallest.right /= Void then
				del_one_child (n_smallest, True)
			else
				del_no_child (n_smallest)
			end
		end

	-- returns the smallest node
	get_smallest (n: NODE [G]): NODE [G]
		do
			if n.left /= Void then
				Result := get_smallest (n.get_left)
			else
				Result := n
			end

		end

	-- Inorder_output calls inorder_recursion
	inorder_output
		do
			if root /= Void then
				inorder_recursion (get_root)
				io.put_string (output)
				output := ""
			end
		end

	-- Order of output is leftside, root, rightside of binarytree
	inorder_recursion (n: NODE [G])
		do
			if n.left /= Void then
				inorder_recursion (n.get_left)
			end
			output := output + n.value.out + " "
			if n.right /= Void then
				inorder_recursion (n.get_right)
			end
		end

	-- Setter for the root of the binarytree
	set_root (r: detachable NODE [G])
		do
			if attached root as ro then
				root := ro
			end
			ensure
				acceptable_root: root= r
		end

	-- Returns value of the root
	get_root: NODE [G]
		do
			check attached root as r then
				Result := r
			end
		end

	-- Returns the array
	get_array: ARRAY [G]
		do
			i := 0
			inorder_array_recursion (get_root)
			i := 0
			Result := array
		end

	-- In this method it picks first of all the negative numbers of the random binarytree. Then numbers <=5 and the end the straight numbers.
	filter
		do
			if get_array.item (i).out.is_real_64 -- checks if the input is a double/float
			then
				io.put_new_line
				print("THe negative Numbers of the Binarytree: ")
				get_array.do_all(agent (x: G)
				local
					temporary: STRING
					arrayResult : ARRAY [STRING]
				do
					create arrayResult.make_empty
					temporary:=x.out
					if
						temporary.to_real < 0
					then
						from
							i:=0
						until i>arrayResult.upper

						loop
							arrayResult.force (temporary, i)
							print(arrayResult.item(i))
							print(" ")
							i:=i+1
						end
					end
				end)

				io.put_new_line
				print("The numbers lower than 5: ")
				get_array.do_all(agent (x: G)
				local
					temporary: STRING
					arrayResult : ARRAY [STRING]
				do
					create arrayResult.make_empty
					temporary:=x.out
					if
						temporary.to_real <= 5
					then
						from
							i:=0
						until i>arrayResult.upper
						loop
							arrayResult.force (temporary, i)
							print(arrayResult.item(i))
							print(" ")
							i:=i+1
						end
					end
				end)

			io.put_new_line
			print("The straight numbers: ")
			get_array.do_all(agent (x: G)
			local
				temporary: STRING
				arrayResult : ARRAY [STRING]
			do
				create arrayResult.make_empty
				temporary:=x.out

				if temporary.is_integer_64 then
					if
					temporary.to_integer_64\\2  = 0
					then
						from
							i:=0
						until i>arrayResult.upper
						loop
							arrayResult.force (temporary, i)
							print(arrayResult.item(i))
							print(" ")
							i:=i+1
						end
					end
				end

			end)
		end
	end

feature {NONE}
	-- Attributes
	array: ARRAY [G]
	filter_array: ARRAY [G]
	has_bool: BOOLEAN
	output: STRING_8
	is_empty: BOOLEAN
	i:INTEGER

	-- The method inserts the value of the binarytree in the array
	inorder_array_recursion (n: NODE [G])
		do
			if n.left /= Void then
				inorder_array_recursion (n.get_left)
			end
			array.force(n.value,i)
			i:=i+1
			if n.right /= Void then
				inorder_array_recursion (n.get_right)
			end
		end
end
