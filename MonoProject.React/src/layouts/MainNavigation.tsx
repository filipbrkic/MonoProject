import { NavLink } from "react-router-dom";

import classes from "./MainNavigation.module.css"

const MainNavigation = () => {
    return (
        <header className={classes.header}>
            <nav>
                <ul>
                    <li>
                        <NavLink activeClassName={classes.active} to="/" exact>Home</NavLink>
                    </li>
                    <li>
                        <NavLink activeClassName={classes.active} to="/new-vehicle-make">Add New Vehicle Brand</NavLink>
                    </li>
                    <li>
                        <NavLink activeClassName={classes.active} to="/vehicle-owner">Add New Owner</NavLink>
                    </li>
                </ul>
            </nav>
        </header>
    )
};

export default MainNavigation;