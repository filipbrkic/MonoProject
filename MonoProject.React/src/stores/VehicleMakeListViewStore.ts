import { action, makeObservable, observable, runInAction } from "mobx";
import VehicleMakeService from "./VehicleMakeService"

export default class VehicleMakeListViewStore {
    vehicleMakeService: VehicleMakeService;
    constructor() {
        makeObservable(this, { data: observable, getAllVehicleMakeAsync: action });
        this.vehicleMakeService = new VehicleMakeService();
    }

    data = [];
    pagination = null;
    sorting = null;
    filtering = null;

    status = "initial";

    getAllVehicleMakeAsync = async () => {
        try {
            const makeData = await this.vehicleMakeService.getAll();
            runInAction(() => {
                this.data = makeData.data;
            })
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            })
        }
    }
}