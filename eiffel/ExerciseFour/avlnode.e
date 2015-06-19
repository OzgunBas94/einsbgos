note
	description: "Summary description for {AVLNODE}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

class
	AVLNODE[G-> COMPARABLE]

create
	make

feature {NONE}
	make(new_value:G)
		do
			value := new_value
			balance:=0
		end

feature {NONE}
	-- Attributes
	left: detachable AVLNODE[G]
	right: detachable AVLNODE[G]
	parent: detachable AVLNODE[G]
	value: G
	balance:INTEGER

feature {ANY}
	-- Returns the height
	get_balance: INTEGER
	require
		current /= void
	do
		Result := balance
	end

	-- Returns left node
	get_left: detachable AVLNODE[G]
	require
		current /= void
	do
		Result := left
	end

	-- Returns right node
	get_right: detachable AVLNODE[G]
	require
		current /= void
	do
		Result := right
	end

	-- Returns parent node
	get_parent: detachable AVLNODE[G]
	require
		current /= void
	do
		Result := parent
	end

	-- Returns the value
	get_value: G
	require
		current /= void
	do
		Result := value
	end

feature {AVLTREE, AVLNODE} -- setter

	-- Sets the balance
	set_balance(bal:INTEGER)
	do
		balance := bal
	ensure
		balance = bal
	end

	-- Sets left node
	set_left(new_node:detachable AVLNODE[G])
	do
		left := new_node
	ensure
		left = new_node
	end

	-- Sets right node
	set_right(new_node:detachable AVLNODE[G])
	do
		right := new_node
	ensure
		right = new_node
	end

	-- Sets parent node
	set_parent(new_node:detachable AVLNODE[G])
	do
		parent := new_node
	ensure
		parent = new_node
	end

	-- Sets chlid node if possible
	set_child(new_node:AVLNODE[G])
	require
		(get_left = void) or (get_right = void)
	do
		new_node.set_parent(current)
		if new_node.get_value >= value then
			set_right(new_node)
		else
			set_left(new_node)
		end

	ensure
		new_node.get_parent /= void
	end
	-- Sets a new value
	set_value(new_value:G)
	do
		value := new_value
	ensure
		value = new_value
	end

invariant

end
