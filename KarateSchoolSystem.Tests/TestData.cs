using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem.Tests
{
    internal static class TestData
    {
        public static Belt CreateWhiteBelt()
        {
            return new Belt(
                1,
                "White",
                0,
                "Basic stance and etiquette");
        }

        public static Student CreateStudent(int id = 1)
        {
            return new Student(
                id,
                "Anna",
                "Lee",
                $"anna{id}@email.com",
                "secret1",
                DateTime.Today,
                CreateWhiteBelt(),
                "Active");
        }

        public static Instructor CreateInstructor(int id = 2)
        {
            return new Instructor(
                id,
                "Daniel",
                "Kim",
                $"daniel{id}@email.com",
                "secret2",
                "Kata",
                DateTime.Today,
                "Active");
        }

        public static Administrator CreateAdministrator(
            int id = 3,
            int accessLevel = 3)
        {
            return new Administrator(
                id,
                "Maria",
                "Jones",
                $"maria{id}@email.com",
                "secret3",
                "Operations",
                accessLevel);
        }

        public static KarateClass CreateClass(int capacity = 10)
        {
            return new KarateClass(
                1,
                "Beginner Karate",
                "Beginner",
                capacity,
                "Main Dojo");
        }
    }
}