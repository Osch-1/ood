import { Point } from "./point";

export class Frame {
    private _topLeft: Point;
    private _bottomRight: Point;

    constructor(topLeft: Point, bottomRight: Point) {
        if (!topLeft) {
            throw new Error(`Parameter topLeft can't be ${topLeft}}`)
        }

        if (!bottomRight) {
            throw new Error(`Parameter topLeft can't be ${bottomRight}}`)
        }

        this._topLeft = topLeft;
        this._bottomRight = bottomRight;
    }

    public GetTopLeft(): Point {
        return this._topLeft;
    }

    public SetTopLeft(point: Point) {
        if (!point) {
            throw new Error
        }
        this._topLeft = point;
    }

    public GetBottomRight(): Point {
        return this._bottomRight;
    }

    public SetBottomRight(): Point {
        return this._topLeft;
    }
}