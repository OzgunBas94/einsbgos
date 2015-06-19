note
	description: "Summary description for {INTERFACETREE}."
	author: ""
	date: "$Date$"
	revision: "$Revision$"

deferred class INTERFACETREE[G]

feature -- Deferred Methods to be overwritten in subclasses

	insert(value : G) -- Insert - Methode is deferred, contains no implementation
	deferred --abstract
	end

	delete(value : G) -- Delete - Methode is deferred, contains no implementation
	deferred
	end

	has(value : G) : BOOLEAN -- Has- Methode is deferred, contains no implementation
	deferred
	end

end
