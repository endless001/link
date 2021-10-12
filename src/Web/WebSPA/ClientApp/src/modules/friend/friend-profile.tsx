import React from "react";
import avatar from "assets/images/users/avatar-4.jpg";
import  "modules/friend/friend-profile.css";
import {Accordion, Card, Dropdown, Nav} from "react-bootstrap";
import { CustomToggle } from "components/toggle/custom-toggle"


export const FriendProfile = () => {
  return (
    <div className="user-profile-sidebar">
      <div className="px-3 px-lg-4 pt-3 pt-lg-4">
        <div className="user-chat-nav text-right">
          <button type="button" className="btn nav-btn" id="user-profile-hide">
            <i className="ri-close-line"></i>
          </button>
        </div>
      </div>

      <div className="text-center p-4 border-bottom">
        <div className="mb-4">
          <img src={avatar} className="rounded-circle avatar-lg img-thumbnail"
               alt="" />
        </div>

        <h5 className="font-size-16 mb-1 text-truncate">Doris Brown</h5>
        <p className="text-muted text-truncate mb-1"><i
          className="ri-record-circle-fill font-size-10 text-success mr-1"></i> Active</p>
      </div>

      <div className="p-4 user-profile-desc" data-simplebar="init">
        <div className="simplebar-wrapper" >
          <div className="simplebar-height-auto-observer-wrapper">
            <div className="simplebar-height-auto-observer"></div>
          </div>
          <div className="simplebar-mask">
            <div className="simplebar-offset" >
              <div className="simplebar-content-wrapper" >
                <div className="simplebar-content">
                  <div className="text-muted">
                    <p className="mb-4">If several languages coalesce, the grammar of the
                      resulting language is more simple and regular than that of the
                      individual.</p>
                  </div>

                  <div id="profile-user-accordion" className="custom-accordion">
                    <Accordion defaultActiveKey="0">
                      <Card>
                        <Accordion.Toggle as={Card.Header} eventKey="0">
                              <h5 className="font-size-14 m-0">
                                <i className="ri-user-2-line mr-2 align-middle d-inline-block"></i> About
                                <i className="mdi mdi-chevron-up float-right accor-plus-icon"></i>
                              </h5>
                        </Accordion.Toggle>
                        <Accordion.Collapse eventKey="0">
                          <Card.Body>
                              <div>
                                <p className="text-muted mb-1">Name</p>
                                <h5 className="font-size-14">Doris Brown</h5>
                              </div>
                              <div className="mt-4">
                                <p className="text-muted mb-1">Email</p>
                                <h5 className="font-size-14">adc@123.com</h5>
                              </div>
                              <div className="mt-4">
                                <p className="text-muted mb-1">Time</p>
                                <h5 className="font-size-14">11:40 AM</h5>
                              </div>
                              <div className="mt-4">
                                <p className="text-muted mb-1">Location</p>
                                <h5 className="font-size-14 mb-0">California, USA</h5>
                              </div>
                          </Card.Body>
                        </Accordion.Collapse>
                      </Card>
                      <Card>
                        <Accordion.Toggle as={Card.Header} eventKey="1">
                            <h5 className="font-size-14 m-0">
                              <i className="ri-attachment-line mr-2 align-middle d-inline-block"></i> Attached Files
                              <i className="mdi mdi-chevron-up float-right accor-plus-icon"></i>
                            </h5>
                        </Accordion.Toggle>
                        <Accordion.Collapse eventKey="1">
                          <Card.Body>
                            <Card>
                              <div className="media align-items-center">
                                <div className="avatar-sm mr-3">
                                  <div className="avatar-title bg-soft-primary text-primary rounded font-size-20">
                                    <i className="ri-file-text-fill"></i>
                                  </div>
                                </div>
                                <div className="media-body">
                                  <div className="text-left">
                                    <h5 className="font-size-14 mb-1">admin_v1.0.zip</h5>
                                    <p className="text-muted font-size-13 mb-0">12.5 MB</p>
                                  </div>
                                </div>

                                <div className="ml-4">
                                  <ul className="list-inline mb-0 font-size-18">
                                    <li className="list-inline-item">
                                      <a href="#" className="text-muted px-1">
                                        <i className="ri-download-2-line"></i>
                                      </a>
                                    </li>
                                    <li className="list-inline-item dropdown">

                                      <Dropdown>
                                        <Dropdown.Toggle as={CustomToggle} id="dropdown-custom-components">
                                          <i className="ri-more-fill"></i>
                                        </Dropdown.Toggle>
                                        <Dropdown.Menu>
                                          <Dropdown.Item>
                                            ACTION
                                          </Dropdown.Item>
                                          <Dropdown.Item>
                                            Action
                                          </Dropdown.Item>
                                          <Dropdown.Divider />
                                          <Dropdown.Item >
                                            Delete
                                          </Dropdown.Item>
                                        </Dropdown.Menu>
                                      </Dropdown>
                                    </li>
                                  </ul>
                                </div>
                              </div>
                            </Card>


                          </Card.Body>
                        </Accordion.Collapse>
                      </Card>
                    </Accordion>
                  </div>

                </div>
              </div>
            </div>
          </div>
          <div className="simplebar-placeholder" ></div>
        </div>
        <div className="simplebar-track simplebar-horizontal" >
          <div className="simplebar-scrollbar"></div>
        </div>
        <div className="simplebar-track simplebar-vertical" >
          <div className="simplebar-scrollbar"></div>
        </div>
      </div>
    </div>
  )
}
