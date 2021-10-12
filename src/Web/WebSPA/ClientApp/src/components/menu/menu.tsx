import React from 'react';
import 'components/menu/menu.css';
import { Dropdown, Nav } from 'react-bootstrap';
import avatar from "assets/images/users/avatar-1.jpg";
import logo from "assets/images/logo.svg";
import { CustomToggle } from "components/toggle/custom-toggle"
import {Link} from "react-router-dom";
import userManager from "utils/user-manager";


export const Menu = () => {
  const logout = (event: any) => {
    event.preventDefault();
    userManager.signoutRedirect();
    userManager.removeUser();
  };
    return(
        <div className="side-menu flex-lg-column mr-lg-1">
            <div className="navbar-brand-box">
                <a  className="logo logo-dark">
                        <span className="logo-sm">
                            <img src={logo} alt="" height="30"/>
                        </span>
                </a>
            </div>

            <div className="flex-lg-column my-auto">
                <Nav defaultActiveKey="/home" className="side-menu-nav justify-content-center">
                    <Nav.Item as="li">
                      <Link to="/settings" className="nav-link">
                            <i className="ri-user-2-line"></i>
                      </Link>
                    </Nav.Item>
                    <Nav.Item as="li">
                      <Link to="/" className="nav-link">
                            <i className="ri-message-3-line"></i>
                      </Link>
                    </Nav.Item>
                    <Nav.Item  as="li">
                      <Link to="/group" className="nav-link">
                        <i className="ri-group-line"></i>
                      </Link>
                    </Nav.Item>
                    <Nav.Item as="li">
                      <Link to="/contact" className="nav-link">
                             <i className="ri-contacts-line"></i>
                      </Link>
                    </Nav.Item>
                    <Nav.Item  as="li">
                      <Link to="/settings" className="nav-link">
                            <i className="ri-settings-2-line"></i>
                      </Link>
                    </Nav.Item>
                </Nav>

            </div>

            <div className="flex-lg-column d-none d-lg-block">
                    <Nav defaultActiveKey="/home"  className="side-menu-nav justify-content-center">
                        <Nav.Item as="li">
                            <a className="nav-link">
                                <i className="ri-sun-line theme-mode-icon"></i>
                            </a>
                        </Nav.Item>
                        <Nav.Item as="li">
                            <Dropdown>
                                <Dropdown.Toggle as={CustomToggle} id="dropdown-custom-components">
                                    <img src={avatar} alt="" className="profile-user rounded-circle"/>
                                </Dropdown.Toggle>
                                <Dropdown.Menu>
                                    <Dropdown.Item as="li">
                                        <a className="dropdown-item" href="#">Profile <i
                                            className="ri-profile-line float-right text-muted"></i></a>
                                    </Dropdown.Item>
                                    <Dropdown.Item as="li">
                                        <a className="dropdown-item" href="#">Setting <i
                                            className="ri-settings-3-line float-right text-muted"></i></a>
                                    </Dropdown.Item>
                                    <Dropdown.Divider />
                                    <Dropdown.Item as="li">

                                        <a className="dropdown-item"  onClick={logout}>Log out <i
                                            className="ri-logout-circle-r-line float-right text-muted"></i></a>
                                    </Dropdown.Item>
                                </Dropdown.Menu>
                            </Dropdown>
                        </Nav.Item>
                    </Nav>
            </div>
        </div>);
}

