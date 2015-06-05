note
	description: "Summary description for {AVL_TREE}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

class
	AVL_TREE [T->COMPARABLE]
	inherit GENERIC_TREE [T]
		redefine
			insert,
			has,
			delete
		end


create
	make

feature {NONE} --Initialising the empty binary tree

	make do
		empty := TRUE
		rebalance := FALSE
	end

feature {NONE} --Attributes

	root: detachable AVL_NODE[T]
	empty: BOOLEAN
	rebalance: BOOLEAN

feature --Getters

	get_root: AVL_NODE[T]
--					returns root
		do
			Result:= attached_node(root)
		end

	get_empty: BOOLEAN
					--returns true if tree is empty
		do
			Result:= empty
		end

	get_smallest: AVL_NODE[T]
					--returns smallest value of tree
		require
			tree_not_empty: not get_empty
		local
			tmp_node: attached AVL_NODE[T]
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

	get_biggest: AVL_NODE[T]
					--returns biggest value of tree
		require
			tree_not_empty: not get_empty
		local
			tmp_node: attached AVL_NODE[T]
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

	--insers the new value
	insert(new_value: T)
		local
			new_node: AVL_NODE[T]
		do
			create new_node.make (new_value)

			if get_empty then
				root:= new_node
				empty:= false
			else
				root := insertRec(attached_node(root), new_node)
			end
		end

	insertRec(current_node: AVL_NODE[T] new_node: AVL_NODE[T]) : AVL_NODE[T]
		local
			return: AVL_NODE[T]
			tmp_rotate: AVL_NODE[T]
		do
			return := current_node
			if new_node.get_value.three_way_comparison(current_node.get_value) = 1 then
				if current_node.get_right = void then
					current_node.set_right(new_node)
					new_node.set_parent(current_node)
					current_node.set_balance(current_node.get_balance+1)
					rebalance := current_node.get_balance >= 1
					return := current_node
				else

					current_node.set_right(insertRec(attached_node(current_node.get_right), new_node))
					if rebalance then
						if current_node.get_balance = -1 then
							current_node.set_balance(0)
							rebalance := FALSE
							return := current_node
						elseif current_node.get_balance = 0 then
							current_node.set_balance(1)
							return := current_node
						elseif current_node.get_balance = 1 then
							rebalance := FALSE
							tmp_rotate := attached_node(current_node.get_right)
							if tmp_rotate /= void then
								if tmp_rotate.get_balance = 1 then
									return := rotate_right(current_node)
								else
									return := rotate_double_right_left(current_node)
								end
							end
						end
					else
						return := current_node
					end
				end
			else
				if current_node.get_left = void then
					current_node.set_left(new_node)
					new_node.set_parent(current_node)
					current_node.set_balance(current_node.get_balance-1)
					rebalance := current_node.get_balance <= -1
					return := current_node
				else
				 	current_node.set_left(insertRec(attached_node(current_node.get_left), new_node))
					if rebalance then
						if current_node.get_balance = 1 then
							current_node.set_balance(0)
							rebalance := FALSE
							return := current_node
						elseif current_node.get_balance = 0 then
							current_node.set_balance(-1)
							return := current_node
						elseif current_node.get_balance = -1 then
							rebalance := FALSE
							tmp_rotate := attached_node(current_node.get_left)
							if tmp_rotate.get_balance = -1 then
								return := rotate_left(current_node)
							else
								return := rotate_double_left_right(current_node)
							end
						end
					else
						return := current_node
					end
				end
			end
			Result := return
		end


	has(value:T): BOOLEAN
					--searches for explizit value in tree, returns true if found
		local
			tmp_node: detachable AVL_NODE[T]
			in_tree: BOOLEAN
		do
			in_tree:= false
			from
				tmp_node:= get_root
			until
				in_tree or (tmp_node=void)
			loop
				if tmp_node.get_value.three_way_comparison(value) = 0 then -- tmp_node.get_value = value
					in_tree:= true
				elseif tmp_node.get_value.three_way_comparison(value) = 1 then -- tmp_node.get_value > value
					tmp_node:= tmp_node.get_left
				else
					tmp_node:= tmp_node.get_right
				end
			end
			Result:= in_tree
		end


		delete(to_delete: T)
						--deletes all nodes with the explizit value in tree
			local
				tmp_node: AVL_NODE[T]
			do
				from
					tmp_node:= get_root
				until
					not has(to_delete)
				loop
					if tmp_node.get_value.three_way_comparison(to_delete) = 0 then -- tmp_node.get_value = to_delete
						delete_node(tmp_node)
						tmp_node:= attached_node(get_root)
					elseif tmp_node.get_value.three_way_comparison(to_delete) = 1 then -- tmp_node.get_value > to_delete
						tmp_node:= attached_node(tmp_node.get_left)
					else
						tmp_node:= attached_node(tmp_node.get_right)
					end
				end
			end

feature {NONE} --Subroutine to delete one explicit node in tree

		delete_node(node: AVL_NODE[T])
			local
				tmp_node: AVL_NODE[T]
				tmp_parent: AVL_NODE[T]
				tmp_value: T
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





feature {NONE} -- AVL
	--the rotations balance the tree
	rotate_left(b: AVL_NODE[T]): AVL_NODE[T]
		local
			tmp: detachable AVL_NODE[T]
		do
			tmp := b.get_left
			tmp := attached_node(tmp)
			b.set_left(tmp.get_right)
			tmp.set_right(b)
			b.set_balance(0)
			tmp.set_balance(0)

			Result := tmp
		end

	rotate_right(b: AVL_NODE[T]): AVL_NODE[T]
		local
			tmp: detachable AVL_NODE[T]
		do
			tmp := b.get_right
			tmp := attached_node(tmp)
			b.set_right(tmp.get_left)
			tmp.set_left(b)
			b.set_balance(0)
			tmp.set_balance(0)

			Result := tmp
		end

	rotate_double_left_right(c: AVL_NODE[T]): AVL_NODE[T]
		local
			a: detachable AVL_NODE[T]
			b: detachable AVL_NODE[T]
		do
			a := c.get_left
			a := attached_node(a)
			b := a.get_right
			b := attached_node(b)
			a.set_right(b.get_left)
			b.set_left(a)
			c.set_left(b.get_right)
			b.set_right(c)
			if b.get_balance = -1 then
				c.set_balance(1)
			else
				c.set_balance(0)
			end

			if b.get_balance = 1 then
				a.set_balance(-1)
			else
				a.set_balance(0)
			end

			b.set_balance(0)

			Result := b
		end

	rotate_double_right_left(c: AVL_NODE[T]): AVL_NODE[T]
		local
			a: detachable AVL_NODE[T]
			b: detachable AVL_NODE[T]
		do
			a := c.get_right

			a := attached_node(a)
			b := a.get_left

			b := attached_node(b)
			a.set_left(b.get_right)
			b.set_right(a)
			c.set_right(b.get_left)
			b.set_left(c)
			if b.get_balance = -1 then
				c.set_balance(1)
			else
				c.set_balance(0)
			end

			if b.get_balance = 1 then
				a.set_balance(-1)
			else
				a.set_balance(0)
			end

			b.set_balance(0)

			Result := b
		end




feature --check Attach

	attached_node(d_node: detachable AVL_NODE[T]): attached AVL_NODE[T]
					--returns an attached node
		do
			check attached d_node as a_node then
				Result:= a_node
			end
		end



end
