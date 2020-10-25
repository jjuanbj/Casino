namespace Casino
{
    class Computer : Player{
        
        // TODO: rename Player class to Use, and create Player interface 
        public new static ConsoleOutput ConsoleOutput { get; set; }

        public Computer() : base(Constants.Computer, ConsoleOutput){}   
    }
}