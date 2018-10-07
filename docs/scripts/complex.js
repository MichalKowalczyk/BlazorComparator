function Complex(xx, yy) {
    this.X = xx;
    this.Y = yy;
    this.getX = () => {
        return this.X
    };
    this.getY = () => {
        return this.Y
    };
    this.modul2 = () => {
        return Math.sqrt((this.X * this.X) + (this.Y * this.Y));
    };
    this.add = (z) => {
        return new Complex(this.X + z.X, this.Y + z.Y)
    };
    this.kwadrat = () => {
        return new Complex(Math.pow(this.X, 2) - (Math.pow(this.Y, 2)), 2 * this.X * this.Y);
    };
}