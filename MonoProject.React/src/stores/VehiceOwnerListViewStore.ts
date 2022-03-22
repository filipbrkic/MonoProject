import { action, makeAutoObservable, observable, runInAction } from "mobx";
import VehicleOwnerService from "./VehicleOwnerService";

export default class VehicleOwnerListViewStore {
    vehicleOwnerService: VehicleOwnerService;
    constructor() {
        makeAutoObservable(this, { data: observable, getAllVehicleOwnerAsync: action });
        this.vehicleOwnerService = new VehicleOwnerService();
    }

    data = [];

    status = "initial";

    getAllVehicleOwnerAsync = async () => {
        try {
            const ownerData = await this.vehicleOwnerService.getAll();
            runInAction(() => {
                this.data = ownerData.data;
            })
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            })
        }
    };
}