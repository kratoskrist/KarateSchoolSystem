# Karate School Management System

This project implements a Karate School Management System using C#,
object-oriented programming principles, design patterns, validation,
exception handling, and MSTest unit testing.

## Projects

- KarateSchoolSystem: Contains the domain classes and design patterns.
- KarateSchoolSystem.Tests: Contains MSTest unit tests.

## OOP Principles

- Encapsulation: Validated properties and controlled collection access.
- Inheritance: Student, Instructor, and Administrator inherit from User.
- Abstraction: User is abstract and IReportable/IPaymentStrategy are interfaces.
- Polymorphism: Derived user classes override GetRoleDescription() and ToString().

## Design Patterns

- Factory Pattern: UserFactory creates role-specific User objects.
- Strategy Pattern: Payment uses interchangeable payment strategies.

## Testing

The project uses MSTest and includes constructor, validation, exception,
relationship, inheritance, polymorphism, and ToString tests.

## Author

Benjamin Johnsrud