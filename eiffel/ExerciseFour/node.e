class
	NODE [G]

create
	make

feature

	--Attributes
	left: detachable NODE [G] assign set_left

	right: detachable NODE [G] assign set_right

	parent: detachable NODE [G] assign set_parent

	value: G assign set_value

	make (val: G)
	--Constructor
		do
			value := val
			ensure
				new_value: value= val
		end--make

	set_left (l: detachable NODE [G])
	--set the left Node
		do
			left := l
			ensure
				new_left: left= l
		end--set_left

	get_left: NODE [G]
	--returns the value of the left Node
		do
			check attached left as l then
				Result := l
			end
			ensure
				acceptable_left: get_left = old left
		end--get_left

	set_right (r: detachable NODE [G])
	--set the right Node

		do
			right := r
			ensure
				new_right: right=r
		end--set_right

	get_right: NODE [G]
	--returns the value of the right Node
		do
			check attached right as r then
				Result := r
			end
			ensure
				acceptable_right: get_right = old right
		end--set right

	set_parent (p: detachable NODE [G])
	--set the parent of the Node
		do
			parent := p
			ensure
				new_parent: parent= p
		end--set_parent

	get_parent: NODE [G]
	--returns the value of the Node
		do
			check attached parent as p then
				Result := p
			end
			ensure
				acceptable_parent: get_parent = old parent
		end--get_parent

	set_value (val: G)
	--sets the value of the given parameter value
		do
			value := val
			ensure
				new_value: value = val
		end--set_value

end--class NODE [G]
