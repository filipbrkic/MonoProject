import React from "react";
import classes from "./VehicleMakeList.module.css"
import VehicleMakeList from "./VehicleMakeList";

const VehicleMakeTable: React.FC = () => {
    return (
        <div className={classes.table}>
            <h1>List of Vehicle Brands</h1>
            <table>
                <thead>
                    <tr>
                        <th>
                            Name
                        </th>
                        <th>
                            Abrv
                        </th>
                    </tr>
                </thead>
                <VehicleMakeList />
            </table>
        </div >
    )
};

export default VehicleMakeTable;