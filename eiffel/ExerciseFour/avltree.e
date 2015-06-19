note
	description: "Summary description for {AVLTREE}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

-- Antother three 'AVLTREE'
class
	AVLTREE[G-> COMPARABLE]

-- superclass of the AVLTree is InterfaceTree and with redefine it overrites the methods
inherit
    INTERFACETREE [G]

create
	default_empty

feature {NONE}
	default_empty
		do
			empty := TRUE
			size := 0
		end

feature {NONE} -- Attributtes
	root: detachable AVLNODE[G]
	empty: BOOLEAN
	size: INTEGER

feature {ANY}
	-- Returns the root-node of the treestructure
	get_root: AVLNODE[G]
		require
			treestructure_is_not_empty: not is_empty
		do
			Result := attached_node(root)
		ensure
			result_is_attached: Result /= void
			result_is_root: Result.get_parent = void
		end

	-- Returns the node from the left bottom of the treestructure
	get_smallest: AVLNODE[G]
		require
			treestructure_is_not_empty: not is_empty
		local
			tmp_node: attached AVLNODE[G]
		do
			from
				tmp_node := get_root
			until
				tmp_node.get_left = void
			loop
				tmp_node := attached_node(tmp_node.get_left)
			end
			Result := tmp_node
		ensure
			result_is_attached: Result /= void
			result_is_samallest: Result.get_left = void
		end

	-- Returns the node from the right bottom of the treestructure
	get_biggest: AVLNODE[G]
		require
			treestructure_is_not_empty: not is_empty
		local
			tmp_node: attached AVLNODE[G]
		do
			from
				tmp_node := get_root
			until
				tmp_node.get_right = void
			loop
				tmp_node := attached_node(tmp_node.get_right)
			end
			Result := tmp_node
		ensure
			result_is_attached: Result /= void
			result_is_biggest: Result.get_right = void
		end

	-- Returns number of nodes in the treestructure
	get_size: INTEGER
		do
			Result := size
		end

	-- Returns true if the treestructure is empty
	is_empty: BOOLEAN
		do
			Result := empty
		end

feature {ANY}
	-- Adds new value to the treestructure
	insert(new_value:G)
		local
			new_node: AVLNODE[G]
			tmp_node: AVLNODE[G]
		do
			create new_node.make(new_value)

			if is_empty then
				root := new_node
				size := 1
				empty := false
			else
				from
					tmp_node := attached_node(root)
				until
					(tmp_node.get_value > new_value and tmp_node.get_left = void) or
					(tmp_node.get_value <= new_value and tmp_node.get_right = void)
				loop
					if tmp_node.get_value > new_value then
						tmp_node := attached_node(tmp_node.get_left)
					else
						tmp_node := attached_node(tmp_node.get_right)
					end
				end
				tmp_node.set_child(new_node)
				size := size + 1
				balance_update(new_node)
			end
		end

	-- Deletes all nodes with the value from the treestructure
	delete(value:G)
		local
			tmp_node: AVLNODE[G]
		do
			if not is_empty then
				from
					tmp_node := get_root
				until
					not has(value)
						-- Is true, if the value is deleted
				loop
					if tmp_node.get_value >= value then
						if tmp_node.get_value > value then
							tmp_node := attached_node(tmp_node.get_left)
					    else
							remove_node(tmp_node)
							tmp_node := get_root
						end
					else
						tmp_node := attached_node(tmp_node.get_right)
					end
				end
			end
		end

	-- Searches treestructure for explicit value and return true if found
	has(value: G): BOOLEAN
		local
			tmp_node: detachable AVLNODE[G]
			exists : BOOLEAN
		do
			exists := false
			if not is_empty then
				from
					tmp_node := get_root
				until
					exists or (tmp_node = void)
				loop
					if tmp_node.get_value >= value then
						if tmp_node.get_value>value then
							tmp_node := tmp_node.get_left
						else
							exists := true
						end
					else
						tmp_node := tmp_node.get_right
					end
				end
			end
			Result := exists
		end

		-- Returns an array with the values of the tree from smallest to biggest or invert
		to_array: ARRAY[G]
			local

				tmp_array : ARRAY[G]
				tmp_node : AVLNODE[G]
				i : INTEGER
			do
				create tmp_array.make_filled(get_root.get_value , 0, get_size-1)
				from
					tmp_node := get_smallest
					i := 0
					tmp_array[i] := tmp_node.get_value
				until
					tmp_node = get_biggest
				loop
					tmp_node := attached_node(get_next_bigger_node(tmp_node))
					i := i+1
					tmp_array[i] := tmp_node.get_value
				end
				Result := tmp_array
			end


feature {NONE}
	--checks if the node "child" is the left child of the node "parent"
	is_leftc(parent:AVLNODE[G]; child:AVLNODE[G]): BOOLEAN
	local
		res:BOOLEAN
	do
		res:=false
		if parent.get_left/=void and attached_node(parent.get_left)=child then
			res:=true
		end
		Result:=res
	end

 --updates the balance (of the parent) of the new node
 balance_update(node:AVLNODE[G])
	 do
        if node.get_balance > 1 or node.get_balance < -1 then
            rebalance(node)
        elseif node.get_parent/=void then
            if is_leftc(attached_node(node.get_parent), node) then
               attached_node(node.get_parent).set_balance(attached_node(node.get_parent).get_balance- 1)
            else
               attached_node(node.get_parent).set_balance(attached_node(node.get_parent).get_balance+ 1)
			end
            if attached_node(node.get_parent).get_balance /= 0 then
               balance_update(attached_node(node.get_parent))
            end
  		end
 	end

--decides which rotation is necessary: left, right, left right, right left
rebalance(node:AVLNODE[G])
do
	if node.get_balance < 0 then
    	if attached_node(node.get_left).get_balance > 0 then
        	rotate_left(attached_node(node.get_left))
        end

        rotate_right(node)
    elseif node.get_balance > 0 then
        if attached_node(node.get_right).get_balance < 0 then
        	rotate_right(attached_node(node.get_right))
		end

        rotate_left(node)
    end
end


        rotate_right(node:AVLNODE[G])
--      Right rotation
     	local
     	new_root:AVLNODE[G]

        do
        new_root := attached_node(node.get_left)
        node.set_left (new_root.get_right)
        	if new_root.get_right/=void then
        		attached_node(new_root.get_right).set_parent(node)
        	end--if new_root.get_right/=void then
        new_root.set_parent(node.get_parent)
        if node.get_parent=void then
        	root:=new_root
        else
        	if	node.get_value>=attached_node(node.get_parent).get_value --node is a right child	
        	then
        		attached_node(node.get_parent).set_right (new_root)
        	else
        		attached_node(node.get_parent).set_left (new_root)
        	end
        end--node.get_parent=void then
        new_root.set_right(node)
        node.set_parent (new_root)
        node.set_balance (node.get_balance+1-new_root.get_balance.min(0))
        new_root.set_balance(new_root.get_balance+1+node.get_balance.max (0))
        end


    	rotate_left(node:AVLNODE[G])
   --   left rotation
     	local
        new_root:AVLNODE[G]

        do
        new_root:=attached_node(node.get_right)
        node.set_right (new_root.get_left)
        if new_root.get_left/=void then
        	attached_node(new_root.get_right).set_parent(node)
        end--if new_root.get_right/=void then
        new_root.set_parent(node.get_parent)
        if node.get_parent=void then
        	root:=new_root
        else
        	if	node.get_value>=attached_node(node.get_parent).get_value --node is a right child	
        	then
        		attached_node(node.get_parent).set_right (new_root)
        	else
        		attached_node(node.get_parent).set_left (new_root)
        	end
        end --node.get_parent=void then
        new_root.set_left(node)
        node.set_parent (new_root)
        node.set_balance (node.get_balance-1-new_root.get_balance.max(0))
        new_root.set_balance(new_root.get_balance-1+node.get_balance.min (0))
        end

	-- Deletes one explicit node from the treestructure
	remove_node(r_node: AVLNODE[G])
		local
			tmp_node: AVLNODE[G]
			tmp_parent: AVLNODE[G]
			tmp_value: G
		do
			if r_node.get_left = void and r_node.get_right = void then
				-- Node has no children
				if r_node.get_parent = void then
						-- r_node is root
					root := void
					size := 0
					empty := true
				else
					tmp_parent := attached_node(r_node.get_parent)
					if tmp_parent.get_value > r_node.get_value then
						--node is a left child
						tmp_parent.set_left(void)
						attached_node(r_node.get_parent).set_balance (attached_node(r_node.get_parent).get_balance+1)
					else
						--node is a right child
						tmp_parent.set_right(void)
						attached_node(r_node.get_parent).set_balance (attached_node(r_node.get_parent).get_balance-1)
					end
					size := size - 1
				end
			elseif r_node.get_left = void then
					-- r_node has a right-child
				tmp_node := attached_node(r_node.get_right)
				if r_node.get_parent = void then
					-- r_node is root
					root := tmp_node
					tmp_node.set_parent(void)
				else
					tmp_parent := attached_node(r_node.get_parent)
					tmp_parent.set_child(tmp_node)
					--has a parent. update balance of the parent node
					if is_leftc(attached_node(r_node.get_parent), r_node) then
               			attached_node(r_node.get_parent).set_balance(attached_node(r_node.get_parent).get_balance- 1)
            		else
               			attached_node(r_node.get_parent).set_balance(attached_node(r_node.get_parent).get_balance+ 1)
					end
				end
				size := size - 1
			elseif r_node.get_right = void then
					-- r_node has a left-child
				tmp_node := attached_node(r_node.get_left)
				if r_node.get_parent = void then
						-- r_node is root
					root := tmp_node
					tmp_node.set_parent(void)
				else
					tmp_parent := attached_node(r_node.get_parent)
					tmp_parent.set_child(tmp_node)
					--has a parent. update balance of the parent node
					if is_leftc(attached_node(r_node.get_parent), r_node) then
               			attached_node(r_node.get_parent).set_balance(attached_node(r_node.get_parent).get_balance- 1)
            		else
               			attached_node(r_node.get_parent).set_balance(attached_node(r_node.get_parent).get_balance+ 1)
					end
				end
				size := size - 1
			else
					-- r_node has both children
				from
					tmp_node := attached_node(r_node.get_right)
				until
					tmp_node.get_left = void
				loop
					tmp_node := attached_node(tmp_node.get_left)
				end

				tmp_value := tmp_node.get_value
				r_node.set_value(tmp_value)
				remove_node(tmp_node)
			end
			if r_node.get_parent/=void then
				balance_update(attached_node(r_node.get_parent))
			end
		end

	-- Returns the node with the next bigger or higher 'ranked-equal' value otherwise result is void
	get_next_bigger_node(c_node: AVLNODE[G]): detachable AVLNODE[G]
		local
			tmp_node : detachable AVLNODE[G]
		do
			if c_node.get_right = void then
				from
					tmp_node := attached_node(c_node.get_parent)
				until
					tmp_node = void or tmp_node.get_value > c_node.get_value
				loop
					tmp_node := attached_node(tmp_node.get_parent)
				end
			else
				from
					tmp_node := attached_node(c_node.get_right)
				until
					tmp_node.get_left = void
				loop
					tmp_node := attached_node(tmp_node.get_left)
				end
			end
			Result := tmp_node
		end

feature
	-- Checks if the detachable node is attachhed and returens a attached node
	attached_node(d_node:detachable AVLNODE[G]): attached AVLNODE[G]
		do
			check attached d_node as a_node then
				Result := a_node
			end
		end

	-- Checks if the detachable value is attachhed and returens an attached value
	attached_value(d_value: detachable G): attached G
		do
			check attached d_value as a_value then
				Result := a_value
			end
		end

invariant
	size_is_bigger_zero: get_size >= 0
	if_empty_then_size_is_zero: not is_empty xor get_size = 0
end
