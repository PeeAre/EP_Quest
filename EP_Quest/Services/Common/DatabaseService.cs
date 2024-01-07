using EP_Quest.Models;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;

namespace EP_Quest.Services.Common
{
    public class DatabaseService
    {
        public void EnsurePopulated(QuestDbContext dbContext)
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }

            if (!dbContext.Instructions.Any())
            {
                dbContext.Instructions.AddRange(
                new Instruction()
                {
                    Number = 1,
                    Content = "Это твой <span style=\"color: greenyellow\"><b><i>quest in Warsaw</i></b></span>, сейчас я проведу небольшой инструктаж о том, <span style=\"color: orangered\"><b><i>wie es funktioniert.</i></b></span>"
                },
                new Instruction()
                {
                    Number = 2,
                    Content = "Я приготовил для тебя несколько <span style=\"color: olivedrab\"><b><i>steps</i></b></span>, <span style=\"color: greenyellow\"><b><i>вирішення яких рухатиме твій загальний прогрес квесту.</i></b></span>\r\nИх ты найдешь после инструкций <span style=\"color: olivedrab\"><b><i>in your dashboard.</i></b></span> Не забывай читать описание прежде чем начинать:\r\n<span style=\"color: olivedrab\"><b><i>some steps</i></b></span> могут быть <span style=\"color: orangered\"><b><i>an die Zeit gebunden.</i></b></span>"
                },
                new Instruction()
                {
                    Number = 3,
                    Content = "<span style=\"color: olivedrab\"><b><i>During the quest</i></b></span> нужно будет поработать мозгами, (думаю, проблем возникнуть не должно) <span style=\"color: greenyellow\">\r\n    <b>\r\n        <i>\r\n            і поблукати місцями, де розкидані підказки.\r\n            З таких підказок ти збиратимеш ключі, які відкривають наступне завдання.\r\n        </i>\r\n    </b>\r\n</span>"
                },
                new Instruction()
                {
                    Number = 4,
                    Content = "После того, как ты приступила к выполнению задачи, запустится таймер.\r\n<span style=\"color: greenyellow\"><b><i>За відведений час ти повинна розібратися з цим</i></b></span>,\r\nиначе <s>будешь наказана</s> сервер самоуничтожится и ты уже не сможешь получить свой\r\n<span style=\"color: orangered\"><b><i>Pr<span class=\"deutch-font\">ä</span>sent.</i></b></span> <span style=\"color: olivedrab\"><b><i>Never Ever.!.!!.</i></b></span>:^ )."
                },
                new Instruction()
                {
                    Number = 5,
                    Content = "<div style=\"height: 100%; display: flex; flex-direction: column; justify-content: space-between\">\r\n    <div>\r\n        <span style=\"color: olivedrab;\"><b><i>Let's get it started:)</i></b></span>\r\n    </div>\r\n    <div style=\"font-size: 4px; text-align: end\">Wild Pixels Team - любовь в каждом пикселе.</div>\r\n</div>"
                });
            }
            dbContext.SaveChanges();

            if (!dbContext.Steps.Any())
            {
                dbContext.Steps.AddRange(
                    new Step()
                    {
                        Number = 1,
                        Duration = new TimeSpan(24, 0, 0),
                        Name = "Step one",
                        Description = "Description of the first Step",
                        Content = "Content of the first Step",
                        IsLocked = false
                    },
                    new Step()
                    {
                        Number = 2,
                        Duration = new TimeSpan(24, 0, 0),
                        Name = "Step two",
                        Description = "Description of the second Step",
                        Content = "Content of the second Step",
                    },
                    new Step()
                    {
                        Name = "Step three",
                        Duration = new TimeSpan(24, 0, 0),
                        Number = 3,
                        Description = "Description of the third Step",
                        Content = "Content of the third Step"
                    },
                    new Step()
                    {
                        Name = "Step four",
                        Duration = new TimeSpan(24, 0, 0),
                        Number = 4,
                        Description = "Description of the fourth Step",
                        Content = "Content of the fourth Step"
                    },
                    new Step()
                    {
                        Name = "Step five",
                        Duration = new TimeSpan(24, 0, 0),
                        Number = 5,
                        Description = "Description of the fifth Step",
                        Content = "Content of the fifth Step"
                    });
            }
            dbContext.SaveChanges();
        }
    }
}
