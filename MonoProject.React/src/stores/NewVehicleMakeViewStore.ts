import { action, makeObservable, observable, runInAction } from "mobx";
import { VehicleMakeDto } from "../common/VehicleMakeDto";
import VehicleMakeService from "./VehicleMakeService"

export default class NewVehicleMakeViewStore {
    vehicleMakeService: VehicleMakeService;
    constructor() {
        makeObservable(this, { data: observable, createVehicleMakeAsync: action });
        this.vehicleMakeService = new VehicleMakeService();
    }

    data = [];
    status = "initial";

    createVehicleMakeAsync = async (model: VehicleMakeDto) => {
        try {
            const response = await this.vehicleMakeService.post(model);
            if (response?.status === 200) {
                runInAction(() => {
                    this.status = "success";
                })
            }
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.status = "error";
            })
        }
    }
}