using GenericsToList;

namespace TestList
{
    public class ListTest
    {
        [Theory]
        [InlineData("First Item", "Second Item")]
        public void Compare_Add_Item_Method_New_Collection_With_Collection_List(string firstItem, string secondItem)
        {
            //Arrange
            var listClass = new ListClass<string>();
            var list = new List<string>();

            //Act
            listClass.Add(firstItem);
            listClass.Add(secondItem);

            list.Add(firstItem);
            list.Add(secondItem);

            //Assert
            Assert.Equal(list[0], listClass[0]);
            Assert.Equal(list[1], listClass[1]);
        }


        [Theory]
        [MemberData(nameof(ListElement))]
        public void Remove_Item_Method_To_Collection(ListClass<string> list)
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
        public void Not_Remove_Item_Method_To_Collection(ListClass<string> list)
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
        public void Remove_Item_On_Index_To_Collection(ListClass<string> actualList, List<string> expectedList)
        {
            //Arrange
            var index = 2;

            //Act
            actualList.RemoveAt(index);
            expectedList.RemoveAt(index);
            var equls = true;

            for (var i = 0; i < actualList.Count; i++)
            {
                if (actualList[i] != expectedList[i])
                {
                    equls = false;
                }
            }

            //Assert
            Assert.True(equls);
        }

        [Theory]
        [MemberData(nameof(ListElement))]
        public void Remove_Item_On_Index_To_Collection_Exception(ListClass<string> list)
        {
            //Arrange
            var index = 10;

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(index));
        }

        [Theory]
        [MemberData(nameof(ListElement))]
        public void Contain_Item_To_Collection(ListClass<string> list)
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
        public void Not_Contain_Item_To_Collection(ListClass<string> list)
        {
            //Arrange
            var item = "Post Malone";

            //Act
            var IsContains = list.Contain(item);

            //Assert
            Assert.False(IsContains);
        }

        [Theory]
        [MemberData(nameof(ListElement))]
        public void Examination_Clear_Collection(ListClass<string> actualList)
        {
            //Arrange
            var expectedList = new List<string>();

            //Act
            actualList.Clear();

            //Assert
            Assert.Equal(expectedList, actualList);

        }

        public static IEnumerable<object[]> ListElement()
        {
            yield return new object[]
            {
                new ListClass<string>(){"Keny", "Manta", "Sandy", "Polly", "Dandy"},
            };
        }

        public static IEnumerable<object[]> ItemElement()
        {
            yield return new object[]
            {
                new ListClass<string>(){"Keny", "Manta", "Sandy", "Polly", "Dandy"},
                new List<string>(){ "Keny", "Manta", "Sandy", "Polly", "Dandy" },
            };
        }
    }
}