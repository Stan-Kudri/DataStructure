using DataStructure;
using FluentAssertions;

namespace TestList
{
    public class ArrayListTest
    {
        [Theory]
        [InlineData("First Item", "Second Item")]
        public void Compare_Add_Item_Method_New_Collection_With_Collection_List(string firstItem, string secondItem)
        {
            //Arrange
            var actualList = new ArrayList<string>();
            var expectList = new List<string>();

            //Act
            actualList.Add(firstItem);
            actualList.Add(secondItem);

            expectList.Add(firstItem);
            expectList.Add(secondItem);

            //Assert
            actualList.Should().Equal(expectList);
        }


        [Theory]
        [MemberData(nameof(ListElement))]
        public void Remove_Item_Method_To_Collection(ArrayList<string> list)
        {
            //Arrange
            var item = "Sandy";

            //Act
            var isItemToRemove = list.Remove(item);

            //Assert
            Assert.True(isItemToRemove);
        }

        [Theory]
        [MemberData(nameof(ListElement))]
        public void Not_Remove_Item_Method_To_Collection(ArrayList<string> list)
        {
            //Arrange
            var item = "MOLOND";

            //Act
            var isItemToRemove = list.Remove(item);

            //Assert
            Assert.False(isItemToRemove);
        }

        [Theory]
        [MemberData(nameof(ItemElement))]
        public void Remove_Item_On_Index_To_Collection(ArrayList<string> actualList, List<string> expectedList)
        {
            //Arrange
            var index = 2;

            //Act
            actualList.RemoveAt(index);
            expectedList.RemoveAt(index);

            //Assert
            actualList.Should().Equal(expectedList);
        }

        [Theory]
        [MemberData(nameof(ListElement))]
        public void Remove_Item_On_Index_To_Collection_Exception(ArrayList<string> list)
        {
            //Arrange
            var index = 10;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(index));
        }

        [Theory]
        [MemberData(nameof(ListElement))]
        public void Contain_Item_To_Collection(ArrayList<string> list)
        {
            //Arrange
            var item = "Keny";

            //Act
            var IsContains = list.Contain(item);

            //Assert
            Assert.True(IsContains);
        }

        [Theory]
        [MemberData(nameof(ListElement))]
        public void Not_Contain_Item_To_Collection(ArrayList<string> list)
        {
            //Arrange
            var item = "Post Malone";

            //Act
            var IsContains = list.Contain(item);

            //Assert
            Assert.False(IsContains);
        }

        [Theory]
        [MemberData(nameof(ItemElement))]
        public void Examination_Clear_Collection(ArrayList<string> actualList, List<string> expectedList)
        {
            //Act
            actualList.Clear();
            expectedList.Clear();

            //Assert
            actualList.Should().Equal(expectedList);
        }

        public static IEnumerable<object[]> ListElement()
        {
            yield return new object[]
            {
                new ArrayList<string>(){"Keny", "Manta", "Sandy", "Polly", "Dandy"},
            };
        }

        public static IEnumerable<object[]> ListWithEmptyItems()
        {
            yield return new object[]
            {
                new ArrayList<string>(){},
            };
        }

        public static IEnumerable<object[]> ItemElement()
        {
            yield return new object[]
            {
                new ArrayList<string>(){"Keny", "Manta", "Sandy", "Polly", "Dandy"},
                new List<string>(){ "Keny", "Manta", "Sandy", "Polly", "Dandy" },
            };
        }
    }
}