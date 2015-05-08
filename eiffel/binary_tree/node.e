note
	description: "Node of a binary tree."
	author: "Selina Magnin"
	date: "$Date$"
	revision: "$Revision$"

class
	NODE

create
	make

feature --Initialization

	value: INTEGER
	parent: detachable NODE
	left: detachable NODE
	right: detachable NODE

feature	{MY_TREE}--create node with value 'my_value'

	make (my_value: INTEGER)
		do
			value:= my_value
		ensure
			value_is_set: value = my_value
		end

feature {MY_TREE} --set value of node

	set_value(my_value:INTEGER)
		do
			value:= my_value
		end

feature {MY_TREE} --set parent of node

	set_parent (my_parent: detachable NODE)
	do
			parent:= my_parent
		ensure
			parent_is_set: parent = my_parent
	end

feature {MY_TREE}--set left child of node

	set_left (my_left: detachable NODE) do
			left:= my_left
		ensure
			left_is_set: left = my_left
	end

feature {MY_TREE}--set right child of node

	set_right (my_right: detachable NODE) do
			right:= my_right
		ensure
			right_is_set: right = my_right
	end

feature --gives value of node

	get_value : INTEGER do
		Result := value
		ensure
			Result_is_set: Result = value
	end

feature --gives parent of node

	get_parent : detachable NODE do
		Result := parent
		ensure
			Result_is_set: Result = parent
	end

feature --gives left child of node

	get_left : detachable NODE
	do
		Result := left
		ensure
			Result_is_set: Result = left
	end

feature --gives right child of node

	get_right : detachable NODE do
		Result := right
		ensure
			Result_is_set: Result = right
	end

feature
	invariant
		--current_bigger_left: current.get_value > current.get_left.get_value
		--current_smaller_right: current.get_value < attached_node(current.get_right).get_value
		--right_bigger_left: attached_node(current.get_left).get_value < attached_node(current.get_right).get_value


end
