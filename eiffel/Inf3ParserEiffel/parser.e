--Class PARSER
class
	PARSER

create
	make

feature
	--Constructor
	-- create an empty string
	make
		do
			create s.make_empty
		end
 feature {NONE}
	--Private Attributes
	-- 's' is the String that should be parsed.
	s: STRING

 feature
	--Public method for parsing the string which is given.
	--This method also checks the rules for the given String, if it can be parsed or not.
	--If the String is againt of one of the rules a helpful error message will be printed.
	--If the given String complies with the rules it can be parsed and the method parse_equation will be called with the string which is given as parameter and
	--param: input-> Is the String that should be parsed.
	parse (input: STRING)
		do
			s := input -- input is a String
			if s.is_empty then -- checks if  the string is empty?
				io.put_string ("EXCEPTION: String is empty")
			else
				if (not s.item (1).is_digit or s.item (1) = '0') and not (s.item (1) = '(') then -- only 1-9 and '(' is allowed at the first index - other characters are forbidden
					io.put_string ("EXCEPTION: character is not allowed at the first position")
				else

					if( not s.item (s.capacity).is_digit or s.item (s.capacity)= '0') and not (s.item (s.capacity) = ')') then --capacity is like the length gives you the last index ->
						io.put_string ("EXCEPTION: characzer is not allowed at the last position")       --only 1-9 and ')' is allowed at the last index - other characters are forbidden
					else

						if not (s.occurrences ('(') = s.occurrences (')')) then								-- the method occurrences is the  Number of times of the character '(' or ')' appears in the string
							io.put_string ("EXCEPTION: open brackets must have same number of closed brackets") -- there must be an equal quantitiy of '(' and ')'

						else

								if empty_brackets then  --it is not allowed that there is a empty bracket like this '()'
									io.put_string ("EXCEPTION:  Empty brackets are not allowed !")
								else

									if operater_before_and_after then  -- before and after a operator must be a digit or a valid sign
										io.put_string ("EXCEPTION:  there must be a digit before or after the given operator.")
									else

										if not_allowed_character then
											io.put_string ("EXCEPTION: given character is not allowed!")
										else

											if single_zero then  --single zeros without a digit befor are invalid
												io.put_string ("EXCEPTION: a single zero is not allowed!")
											else

												if s.occurrences ('=') > 1 then  -- checks if there more then one '=' using the method occurrences
													io.put_string ("EXCEPTION: only one '=' is allowed")
												else

													io.put_string ("THE RESULT OF '" + s + "' IS: " + parse_equation ) -- if everything is checked then it will be beginn to parse
												end
										end
									end
								end
							end
						end
					end
				end
			end
		end


 feature {NONE}
	--the method parse_equation returns equation.
	--first it checks if there is '=' in the given string if not, parse_expression will be called


	parse_equation: STRING
		local
			res: STRING
			left, right: INTEGER
		do
			res := ""
			if s.occurrences ('=') = 0 then
				res := parse_expression
			else
				if s.occurrences ('=') = 1 then
					left := parse_expression.to_integer  	 -- to_integer: parses the expression to an Integer
					s.remove (1)                              -- remove: removes character at the first position
					right := parse_expression.to_integer
					res := (left = right).out
				end
			end
			Result := res
		end


 feature {NONE}
	--the method parse_expression returns expression.
	--first it checks if there is '+' in the given string if not, parse_term will be called
	--if the occurrence of '+' is >=0 then the left and right side will be parsed with the method to_integer

	parse_expression: STRING
		local
			res: STRING
			left, right: INTEGER
		do
			res := ""
			if s.occurrences ('+') = 0 then
				res := parse_term
			else
				if s.occurrences ('+') > 0 then
					left := parse_term.to_integer
					res := left.out
					from
					until
						s.occurrences ('+') = 0 or s.item (1) /= '+'
					loop
						s.remove (1)
						right := parse_term.to_integer
						res := (res.to_integer + right).out
					end
				end
			end
			Result := res
		end


 feature {NONE}
	--the method parse_term returns term.
	--first it checks if there is '*' in the given string if not, parse_factor will be called
	--if the occurrence of '*' is >=0 then the left and right side will be parsed with the method to_integer

	parse_term: STRING
		local
			res: STRING
			left, right: INTEGER
		do
			if s.occurrences ('*') = 0 then
				res := parse_factor
			else
				res := ""
				if s.occurrences ('*') > 0 then
					left := parse_factor.to_integer
					res := left.out
					from
					until
						s.occurrences ('*') = 0 or s.item (1) /= '*'
					loop
						s.remove (1)
						right := parse_factor.to_integer
						res := (res.to_integer * right).out
					end
				end
			end
			Result := res
		end


 feature {NONE}
	--the method parse_factor returns factor.
	--first it checks if there is not '(' at the first index, it returns parse_constant.to_integer
	--if there is a '(' at the first index,then  the '(' will be removed and returns parse_expression.to_integer

	parse_factor: STRING
		local
			res: INTEGER
		do
			if s.item (1) /= '(' then
				res := parse_constant.to_integer
			else
				if s.item (1) = '(' then
					s.remove (1)
					res := parse_expression.to_integer
					if s.item (1) = ')' then
						s.remove (1)
					end
				end
			end
			Result := res.out
		end

 feature {NONE}
	--the method parse_constant returns constant.
	--if digit_wo_zero it goes through the loop and res+ the item at the first pos.
	--and then remove becouse we always need the first position and and this so long until is_it_digit is false

	parse_constant: STRING
		local
			res: STRING
		do
			res := ""
			if is_digit_wo_zero then
				from
				until
					is_it_digit = False
				loop
					res := res + s.item (1).out
					s.remove (1)
				end
			end
			Result := res
		end

 feature {NONE}
	--Checks if first character in the string is a digit
	--the method is_it_digit returns a BOOLEAN.
	--is_digit is a method of Eiffel

	is_it_digit: BOOLEAN
		local
			res: BOOLEAN
		do
			if s.is_empty = False then
				res := s.item (1).is_digit
			else
				res := False
			end
			Result := res
		end

 feature {NONE}
	--this method checks if the first character in the string is a digit without zero (1-9) and returns a BOOLEAN.
	--But first it checks if the string is empty .

	is_digit_wo_zero: BOOLEAN
		local
			res: BOOLEAN
		do
			if s.is_empty = False then
				res := s.item (1).is_digit and s.item (1).out.to_integer /= 0
			else
				res := False
			end
			Result := res
		end

 feature {NONE}
	--this method checks if there are brackets without content.
	--it goes through the 'for' loop and checks if there a bracket and at this position +1 a closing bracket -> this would be a empty one
	-- method empty_brackets reuturns a BOOLEAN.

	empty_brackets: BOOLEAN
		local
			res: BOOLEAN
			i: INTEGER
		do
			res := False
			from
				i := 1
			until
				i = s.capacity
			loop
				if s.item (i) = '(' and s.item (i + 1) = ')' then
					res := True
				end
				i := i + 1
			end
			Result := res
		end

 feature {NONE}
	--this method checks if there is a digit or brackets before and after + and *.
	--it goes through the 'for' loop and checks the characters before and after the String if there is a not allowed character
	-- examples for forbidden construct '2+(' or ')+3'
	-- the method returns a BOOLEAN.

	operater_before_and_after: BOOLEAN
		local
			res: BOOLEAN
			i: INTEGER
		do
			res := False
			from
				i := 2
			until
				i = s.capacity
			loop
				if (s.item (i) = '+' or s.item (i) = '*') and (not (s.item (i + 1).is_digit or s.item (i + 1) = '(') or not (s.item (i - 1).is_digit or s.item (i - 1) = ')')) then
					res := True
				end
				i := i + 1
			end
			Result := res
		end

 feature {NONE}
	--Checks if the given signs are valid.
	--allowed signs are: '=' '+' '*' '(' ')'
	--it goes through the 'for' loop and checks the characters of the String if there is a not allowed character
	--The method reutrns a BOOLEAN

	not_allowed_character: BOOLEAN
		local
			res: BOOLEAN
			i: INTEGER
		do
			res := False
			from
				i := 1
			until
				i = s.capacity
			loop
				if not (s.item (i).is_digit or s.item (i) = '=' or s.item (i) = '+' or s.item (i) = '*' or s.item (i) = '(' or s.item (i) = ')') then
					res := True
				end
				i := i + 1
			end
			Result := res
		end

 feature {NONE}
	--Checks if there are numbers with a single zero. This would be invalid.
	--it goes through the 'for' loop starting at position 2 because its already invalid that 0 is at first position
	-- and checks the characters of the String at position i-1 if there is a single zero
	--the method returns a BOOLEAN
	single_zero: BOOLEAN
		local
			res: BOOLEAN
			i: INTEGER
		do
		res := False
			from
				i := 2
			until
				i = s.capacity + 1
			loop
				if s.item (i).out.is_integer and s.item (i) = '0' and not s.item (i - 1).out.is_integer then -- invalid is if there is no digit before the zero
					res := True																				 -- for example 01 but 10 is valid
				end
				i := i + 1
			end
			Result := res
		end

end
