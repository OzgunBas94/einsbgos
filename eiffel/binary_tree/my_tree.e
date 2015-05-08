note
	description: "Class creates a binary tree for Integer values."
	author: "Selina Magnin"
	date: "$Date$"
	revision: "$Revision$"

class
	MY_TREE

create
	make

feature {NONE} --Initialising the empty binary tree

	make do
		empty := TRUE
	end

feature {NONE} --Attributes

	root: detachable NODE
	empty: BOOLEAN

feature --Getters

	get_root: NODE
					--returns root
		require
			tree_not_empty: not get_empty
		do
			Result:= attached_node(root)
		ensure
			res_attached: Result/=void
			is_root: Result.get_parent = void
		end

	get_empty: BOOLEAN
					--returns true if tree is empty
		do
			Result:= empty
		end

	get_smallest: NODE
					--returns smallest value of tree
		require
			tree_not_empty: not get_empty
		local
			tmp_node: attached NODE
		do
			from
				tmp_node:= get_root
			until
				tmp_node.get_left = void
			loop
				tmp_node:= attached_node(tmp_node.get_left)
			end
			Result:= tmp_node
		ensure
			res_attached: Result/=void
			is_smallest: Result.get_left=void
		end

	get_biggest: NODE
					--returns biggest value of tree
		require
			tree_not_empty: not get_empty
		local
			tmp_node: attached NODE
		do
			from
				tmp_node:= get_root
			until
				tmp_node.get_right=void
			loop
				tmp_node:= attached_node(tmp_node.get_right)
			end
			Result:= tmp_node
		ensure
			res_attached: Result/=void
			is_biggest: Result.get_right=void
		end


feature --routines

	insert (new_value: INTEGER)
					--adds value to binary tree
		local
			new_node: NODE
			tmp_node: NODE
		do
			create new_node.make (new_value)

			if get_empty then
				root:= new_node
				empty:= false
			else
				from --begin from here, initialize beginer node (root)
					tmp_node:= attached_node(root)
				until --loop goes until the boolean gives true
					(tmp_node.get_value > new_value and tmp_node.get_left = void) or
					(tmp_node.get_value < new_value and tmp_node.get_right = void)
				loop --goes through tree to find suitable end of tree to add node
					if tmp_node.get_value > new_value then
						tmp_node:= attached_node(tmp_node.get_left)
					else
						tmp_node:= attached_node(tmp_node.get_right)
					end
				end

				if new_value >= tmp_node.get_value then
					tmp_node.set_right (new_node)
					new_node.set_parent (tmp_node)
				else
					tmp_node.set_left (new_node)
					new_node.set_parent (tmp_node)
				end
			end

			ensure
				value_added: has(new_value)
	end


	has(value:INTEGER): BOOLEAN
					--searches for explizit value in tree, returns true if found
		require
			tree_not_empty: not get_empty
		local
			tmp_node: detachable NODE
			in_tree: BOOLEAN
		do
			in_tree:= false
			from
				tmp_node:= get_root
			until
				in_tree or (tmp_node=void)
			loop
				if tmp_node.get_value = value then
					in_tree:= true
				elseif tmp_node.get_value > value then
					tmp_node:= tmp_node.get_left
				else
					tmp_node:= tmp_node.get_right
				end
			end
			Result:= in_tree
		end


		delete(to_delete: INTEGER)
						--deletes all nodes with the explizit value in tree
			require
				tree_not_empty: not get_empty
			local
				tmp_node: NODE
			do
				from
					tmp_node:= get_root
				until
					not has(to_delete)
				loop
					if tmp_node.get_value = to_delete then
						delete_node(tmp_node)
						tmp_node:= get_root
					elseif tmp_node.get_value > to_delete then
						tmp_node:= attached_node(tmp_node.get_left)
					else
						tmp_node:= attached_node(tmp_node.get_right)
					end
				end

				ensure
					deleted: not has(to_delete)
			end

feature {NONE} --Subroutine to delete one explicit node in tree

		delete_node(node: NODE)
			local
				tmp_node: NODE
				tmp_parent: NODE
				tmp_value: INTEGER
			do
				if node.get_left = void and node.get_right = void then
--node is leaf
					if node.get_parent = void then
	--node is root
						root:= void
						empty:= true
					else
						tmp_parent:= attached_node(node.get_parent)
						if tmp_parent.get_value > node.get_value then
							tmp_parent.set_left(void)
						else
							tmp_parent.set_right(void)
						end
					end
				elseif node.get_left = void then
--node has only right child
					tmp_node:= attached_node(node.get_right)
					if node.get_parent = void then
	--node is root
						root:= tmp_node
						tmp_node.set_parent(void)
					else
	--node isn't root
						tmp_parent:= attached_node(node.get_parent)
						if tmp_parent.get_value > node.get_value then
							tmp_parent.set_left(tmp_node)
						else
							tmp_parent.set_right(tmp_node)
						end
					end
				elseif node.get_right = void then
--node has only left child
					tmp_node:= attached_node(node.get_left)
					if node.get_parent = void then
	--node is root
						root:= tmp_node
						tmp_node.set_parent (void)
					else
	--node isn't root
						tmp_parent:= attached_node(node.get_parent)
						if tmp_parent.get_value > node.get_value then
							tmp_parent.set_left(tmp_node)
						else
							tmp_parent.set_right(tmp_node)
						end
					end
				else
--node has two children
					from
						tmp_node:= attached_node(node.get_right)
					until
						tmp_node.get_left = void
					loop
						tmp_node:= attached_node(tmp_node.get_left)
					end

					tmp_value := tmp_node.get_value
					node.set_value(tmp_value)
					delete_node(tmp_node)
				end
			end



feature --check Attach

	attached_node(d_node: detachable NODE): attached NODE
					--returns an attached node
		do
			check attached d_node as a_node then
				Result:= a_node
			end
		end

feature
	invariant --does not work, because might be void
		--root_bigger_left: attached_node(root).get_value > attached_node(root.get_left).get_value
		--right_bigger_root: attached_node(root).get_value < attached_node(root.get_right).get_value
		--right_bigger_left: attached_node(root.get_right).get_value > attached_node(root.get_left).get_value


end
