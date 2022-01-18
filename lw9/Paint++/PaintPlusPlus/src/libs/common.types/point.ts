export class Point {
    private _x: number;
    private _y: number;

    constructor(x: number, y: number) {
        this._x = x;
        this._y = y;
    }

    public GetAxis(): number {
        return this._x;
    }

    public SetAxis(value: number) {
        this._x = value;
    }

    public GetOrdinate(): number {
        return this._y;
    }

    public SetOrdinate(value: number) {
        this._y = value;
    }
}