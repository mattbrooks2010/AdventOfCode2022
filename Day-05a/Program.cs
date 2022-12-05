var stacks = new Stack<char>[9];
var init = true;
var line = string.Empty;

while ((line = Console.ReadLine()) != null)
{
    if (init)
    {
        if (line.Length > 0)
        {
            var idx = 0;

            for (var i = 1; i < line.Length; i += 4)
            {
                var crate = line[i];
                
                if (char.IsLetter(crate))
                {
                    if (stacks[idx] == null)
                    {
                        stacks[idx] = new Stack<char>();
                    }

                    stacks[idx].Push(crate);
                }

                idx++;
            }
        }
        else
        {
            init = false;

            for (var i = 0; i < stacks.Length; i++)
            {
                // Reverses sequence of items in the stack
                stacks[i] = new Stack<char>(stacks[i]);
            }
        }
    }
    else
    {
        var instr = line.Split(' ');
        var qty = int.Parse(instr[1]);
        var from = int.Parse(instr[3]) - 1;
        var to = int.Parse(instr[5]) - 1;

        for (var i = 0; i < qty; i++)
        {
            stacks[to].Push(stacks[from].Pop());
        }
    }
}

foreach (var stack in stacks)
{
    Console.Write(stack.Peek());
}

Console.WriteLine();
