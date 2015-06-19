class
	APPLICATION

create
	make

feature
	-- Creates a new Binarytree b and ReturnRandom r
	b: BINARYTREE[REAL]
	r: RETURNRANDOM

	make
		do
			-- Creates the root for the Binarytree
			create r.make
			-- Seet for random Positon fo Random to start count
			r.set_random_seet (7)
			create b.make (r.new_random_real)

			-- Insert the nodes
			b.insert (r.new_random_real)
			b.insert (r.new_random_real)
			b.insert (r.new_random_real)
			b.insert (r.new_random_real)
			b.insert (r.new_random_real)

			-- Inorder
			io.put_string ("The inorder output: ")
			b.inorder_output
			io.new_line
			b.filter

			print("hallo")
			io.new_line
			print("haukd")

		end--make

end--class TESTING
