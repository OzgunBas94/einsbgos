
--Main class
class
	APPLICATION

--APPLICATION inherits ARGUMENTS.
inherit

	ARGUMENTS

-- start with make.
create
	make

--Private attributes
feature {NONE}


	p: PARSER

	--The main
	--Checks how many arguments are given and prints a helpful error message if
	--the amount of arguments is wrong or the given arguments are wrong.
	make (arguments: ARRAY [STRING])
		local
			file: PLAIN_TEXT_FILE --initialize the file
			s: STRING
		do
			s := ""
			create p.make  -- creating a new parser
			arguments.remove_head (1) --removes the header (the path) for example C\Ozgun Bas..

			if arguments.capacity = 1 then -- if there are one argument, it is a equation without a file and will be calculated directly
				p.parse (arguments.item (1))
			else
				if arguments.capacity = 2 then 											--if there are two arguments and the first arg is File then a file will be created
					if arguments.item (1).is_equal ("file")  or  arguments.item (1).is_equal ("File")or  arguments.item (1).is_equal ("FILE")  then
						create file.make_with_name (arguments.item (2))					-- if a file access exists 	
						if file.access_exists then										-- and the file ist empty -> Exception message will come
							if file.is_empty then
								io.put_string ("EXCEPTION: File '" + arguments.item (2) + "' is empty.")
							else
								create file.make_open_read (arguments.item (2))			 -- if the file is not empty
								from													 -- opens the path (the seccond argument)and reads it using a loop
								until													 -- until the end of the line and pares the string
									file.end_of_file
								loop
									file.read_line
									s.make_from_string (file.last_string)				-- method last_sting is: read the last string
									p.parse (s)

									if not file.end_of_file then						 -- if its not the end of the end of the file the next line will be read
										io.new_line
									end
								end
									file.close											 -- file will be closed
							end
						else
							io.put_string ("EXCEPTION: File '" + arguments.item (2) + "' does not exist.")
						end
					else
						io.put_string ("EXCEPTION: Expected 'file'  as first paramter but got '" + arguments.item (1) + "'")
					end
				else
					io.put_string ("Error: Only one ore two parameters are allowed. You gave " + arguments.capacity.out + " parameters! pls check your input")
				end
			end
		end

end
