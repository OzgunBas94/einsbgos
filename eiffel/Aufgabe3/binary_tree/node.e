note
	description: "Node of a binary tree."
	author: "Selina Magnin"
	date: "$Date$"
	revision: "$Revision$"

class
	NODE [T]

create
	make

feature --Initialization

	value: T
	parent: detachable NODE[T]
	left: detachable NODE[T]
	right: detachable NODE[T]

feature	{GENERIC_TREE}--create node with value 'my_value'

	make (my_value: T)
		do
			value:= my_value
		ensure
			value_is_set: value = my_value
		end

feature {GENERIC_TREE} --set value of node

	set_value(my_value:T)
		do
			value:= my_value
		end

feature {GENERIC_TREE} --set parent of node

	set_parent (my_parent: detachable NODE[T])
	do
			parent:= my_parent
		ensure
			parent_is_set: parent = my_parent
	end

feature {GENERIC_TREE}--set left child of node

	set_left (my_left: detachable NODE[T]) do
			left:= my_left
		ensure
			left_is_set: left = my_left
	end

feature {GENERIC_TREE}--set right child of node

	set_right (my_right: detachable NODE[T]) do
			right:= my_right
		ensure
			right_is_set: right = my_right
	end

feature --gives value of node

	get_value : T do
		Result := value
	end

feature --gives parent of node

	get_parent : detachable NODE[T] do
		Result := parent
	end

feature --gives left child of node

	get_left : detachable NODE[T]
	do
		Result := left
		ensure
			Result_is_set: Result = left
	end

feature --gives right child of node

	get_right : detachable NODE[T] do
		Result := right
		ensure
			Result_is_set: Result = right
	end
end
