note
	description: "Summary description for {RETURNRANDOM}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

-- The class RenturnRandom returns random numbers for the trees
class
	RETURNRANDOM

create
	make

feature
	-- Attributes
	first_number:REAL
	last_number:REAL
	random_seed:INTEGER
	i:INTEGER

	-- Constructor for TestingRandom
	make
	do
		create random_sequence.make
	end

	-- Sets Seet which decides where Random starts counting
	set_random_seet(r_seed:INTEGER)
	do
		random_seed := r_seed
	end

	-- Method that returns random real
	new_random_real:REAL
 	do
 		random_sequence.set_seed (random_seed)
 		random_sequence.forth

   		first_number:=random_sequence.real_item -- Float
   		io.put_new_line
   		print("Random first number: ")
   		print(first_number)
   		io.put_new_line
   		last_number:=random_sequence.item.to_integer_16 -- Integer
   		print("Random Integer numbers: ")
   		print(last_number)
   		io.put_new_line
   		Result := first_number + last_number * 10
   		io.put_new_line
 	end

 	--new_random_string : STRING
 	--do
	--	stringWord := ""
 	--end

feature {NONE}
	-- Attribute
 	random_sequence: RANDOM
end
