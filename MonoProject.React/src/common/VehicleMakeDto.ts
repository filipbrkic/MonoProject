export class VehicleMakeDto {
    id: number;
    name: string;
    abrv: string;
    constructor(id: number, name: string, abrv: string) {
        this.id = id;
        this.name = name;
        this.abrv = abrv;
    }
}