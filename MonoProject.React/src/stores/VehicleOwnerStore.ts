import { makeAutoObservable, runInAction } from "mobx";
import { VehicleOwnerDto } from "../common/VehicleOwnerDto";
import { post, getAll } from "./VehicleOwnerService";

export default class VehicleOwnerStore {
    constructor() {
        makeAutoObservable(this);
    }

    data = [];
    pagination = null;
    sorting = null;
    filtering = null;

    status = "initial";

    createVehicleOwnerAsync = async (model: VehicleOwnerDto) => {
        try {
            const response = await post(model);
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
    };

    getAllVehicleOwnerAsync = async () => {
        try {
            const ownerData = await getAll();
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
