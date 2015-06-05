note
	description: "Summary description for {AVL_NODE}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

class
	AVL_NODE [T]

create
	make

feature --Initialization

	value: T
	parent: detachable AVL_NODE[T]
	left: detachable AVL_NODE[T]
	right: detachable AVL_NODE[T]
	balance: INTEGER

feature	{GENERIC_TREE}--create node with value 'my_value'

	make (my_value: T)
		do
			value:= my_value
			balance := 0
		end

feature {GENERIC_TREE} --set value of node

	set_value(my_value:T)
		do
			value:= my_value
		end

feature {GENERIC_TREE} --set parent of node

	set_parent (my_parent: detachable AVL_NODE[T])
	do
			parent:= my_parent
		ensure
			parent_is_set: parent = my_parent
	end

feature {GENERIC_TREE}--set left child of node

	set_left (my_left: detachable AVL_NODE[T]) do
			left:= my_left
		ensure
			left_is_set: left = my_left
	end

feature {GENERIC_TREE}--set right child of node

	set_right (my_right: detachable AVL_NODE[T]) do
			right:= my_right
		ensure
			right_is_set: right = my_right
	end

feature --gives value of node

	get_value : T do
		Result := value
	end

feature --gives parent of node

	get_parent : detachable AVL_NODE[T] do
		Result := parent
	end

feature --gives left child of node

	get_left : detachable AVL_NODE[T]
	do
		Result := left
		ensure
			Result_is_set: Result = left
	end

feature --gives right child of node

	get_right : detachable AVL_NODE[T] do
		Result := right
		ensure
			Result_is_set: Result = right
	end

feature{GENERIC_TREE}

	get_balance :detachable INTEGER
		do
			Result := balance
			ensure
			Result_is_set: Result = balance
		end

	set_balance(new_balance:detachable INTEGER)
		do
			balance := new_balance
		end

end
