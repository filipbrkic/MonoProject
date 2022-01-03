export class VehicleMakeDto {
    id: number | null;
    name: string;
    abrv: string;
    constructor(id: number | null, name: string, abrv: string) {
        this.id = id;
        this.name = name;
        this.abrv = abrv;
    }
}