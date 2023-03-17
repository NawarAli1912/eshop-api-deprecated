namespace eshop.Domain.Customers.ValueObjects;

// we are declaring the id as a strongly typed id to solve the
// Primitive Obsession Anti-Pattern
// it should be immutable, structural equality and strongly Typed 
// all those came in one package which is the record.
public record CustomerId(Guid Value);
