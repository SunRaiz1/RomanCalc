using Avalonia.Controls;
using Avalonia.VisualTree;

namespace UITestsForRomanNumbersCalculator
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();
            String t = "I";
            String sum = "II";

            await Task.Delay(100);

            var buttonNimber = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "I");
            var buttonClear = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Delete");
            var buttonPlus = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Plus");
            var buttonEqual = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "Ravno");
            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First();

            buttonNimber.Command.Execute(buttonNimber.CommandParameter);

            await Task.Delay(50);

            var text = textbox.Text;

            Assert.True(text.Equals(t));

            buttonPlus.Command.Execute(buttonPlus.CommandParameter);
            buttonNimber.Command.Execute(buttonNimber.CommandParameter);
            buttonEqual.Command.Execute(buttonEqual.CommandParameter);

            await Task.Delay(50);

            text = textbox.Text;

            Assert.True(text.Equals(sum));

            buttonClear.Command.Execute(buttonClear.CommandParameter);

            await Task.Delay(50);

            text = textbox.Text;

            Assert.True(text.Equals(""));
        }
    }
}