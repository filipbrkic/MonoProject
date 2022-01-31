import { makeAutoObservable, runInAction } from "mobx";
import { VehicleMakeDto } from "../common/VehicleMakeDto";
import { post, getAll, update } from "./VehicleMakeService";

export default class VehicleMakeStore {
    constructor() {
        makeAutoObservable(this);
    }

    data = [];
    pagination = null;
    sorting = null;
    filtering = null;

    status = "initial";

    createVehicleMakeAsync = async (model: VehicleMakeDto) => {
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

    getAllVehicleMakeAsync = async () => {
        try {
            const makeData = await getAll();
            runInAction(() => {
                this.data = makeData.data;
            })
        } catch (error) {
            runInAction(() => {
                this.status = "error";
            })
        }
    };

    updateVehicleMakeAsync = async (model: VehicleMakeDto) => {
        try {
            const response = await update(model);
            if (response?.status === 200) {
                runInAction(() => {
                    this.status = "success";
                })
            }
        } catch (error) {
            runInAction(() => {
                this.status = "error"
            });
        }
    }
}
