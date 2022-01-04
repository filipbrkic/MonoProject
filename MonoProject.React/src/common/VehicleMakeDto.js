export class VehicleMakeDto {
    id;
    name;
    abrv;
    constructor(id, name, abrv) {
        this.id = id;
        this.name = name;
        this.abrv = abrv;
    }
}