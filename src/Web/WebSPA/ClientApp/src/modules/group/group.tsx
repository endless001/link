import React, {useState} from "react";
import {CreateGroupModal} from "modules/group/create-group-modal";


const Group = () => {

  const [open, setOpen] = useState(false);
  const handleClose = () => setOpen(false);

  return(
    <div className="tab-pane active" id="pills-groups" role="tabpanel" aria-labelledby="pills-groups-tab">
      <div>
        <div className="p-4">
          <div className="user-chat-nav float-right">
            <div data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Create group">
              <button type="button"  onClick={()=>setOpen(true)}  className="btn btn-link text-decoration-none text-muted font-size-18 py-0">
                <i className="ri-group-line mr-1"></i>
              </button>
            </div>

          </div>
          <h4 className="mb-4">Groups</h4>
        </div>

        <CreateGroupModal HandleClose={handleClose} Open={open} Title="Create New Group"/>

        <div className="p-4 chat-message-list chat-group-list" data-simplebar="init">
          <div className="simplebar-wrapper">
            <div className="simplebar-height-auto-observer-wrapper">
              <div className="simplebar-height-auto-observer"></div>
            </div>
            <div className="simplebar-mask">
              <div className="simplebar-offset">
                <div className="simplebar-content-wrapper">
                <div className="simplebar-content">


                    <ul className="list-unstyled chat-list">
                      <li>
                        <a href="#">
                          <div className="media align-items-center">
                            <div className="chat-user-img mr-3">
                              <div className="avatar-xs">
                                                        <span
                                                          className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                            G
                                                        </span>
                              </div>
                            </div>
                            <div className="media-body overflow-hidden">
                              <h5 className="text-truncate font-size-14 mb-0">#General</h5>
                            </div>
                          </div>
                        </a>
                      </li>

                      <li>
                        <a href="#">
                          <div className="media align-items-center">
                            <div className="chat-user-img mr-3">
                              <div className="avatar-xs">
                                                        <span
                                                          className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                            R
                                                        </span>
                              </div>
                            </div>
                            <div className="media-body overflow-hidden">
                              <h5 className="text-truncate font-size-14 mb-0">#Reporting <span
                                className="badge badge-soft-danger badge-pill float-right">+23</span></h5>
                            </div>
                          </div>
                        </a>
                      </li>

                      <li>
                        <a href="#">
                          <div className="media align-items-center">
                            <div className="chat-user-img mr-3">
                              <div className="avatar-xs">
                                                        <span
                                                          className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                            D
                                                        </span>
                              </div>
                            </div>
                            <div className="media-body overflow-hidden">
                              <h5 className="text-truncate font-size-14 mb-0">#Designers</h5>
                            </div>
                          </div>
                        </a>
                      </li>

                      <li>
                        <a href="#">
                          <div className="media align-items-center">
                            <div className="chat-user-img mr-3">
                              <div className="avatar-xs">
                                                        <span
                                                          className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                            D
                                                        </span>
                              </div>
                            </div>
                            <div className="media-body overflow-hidden">
                              <h5 className="text-truncate font-size-14 mb-0">#Developers <span
                                className="badge badge-soft-danger badge-pill float-right">New</span></h5>
                            </div>
                          </div>
                        </a>
                      </li>

                      <li>
                        <a href="#">
                          <div className="media align-items-center">
                            <div className="chat-user-img mr-3">
                              <div className="avatar-xs">
                                                        <span
                                                          className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                            P
                                                        </span>
                              </div>
                            </div>
                            <div className="media-body overflow-hidden">
                              <h5 className="text-truncate font-size-14 mb-0">#Project-alpha</h5>
                            </div>
                          </div>
                        </a>
                      </li>

                      <li>
                        <a href="#">
                          <div className="media align-items-center">
                            <div className="chat-user-img mr-3">
                              <div className="avatar-xs">
                                                        <span
                                                          className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                            B
                                                        </span>
                              </div>
                            </div>
                            <div className="media-body overflow-hidden">
                              <h5 className="text-truncate font-size-14 mb-0">#Snacks</h5>
                            </div>
                          </div>
                        </a>
                      </li>
                    </ul>
                  </div>
                </div>
              </div>
            </div>
            <div className="simplebar-placeholder"></div>
          </div>
          <div className="simplebar-track simplebar-horizontal">
            <div className="simplebar-scrollbar"></div>
          </div>
          <div className="simplebar-track simplebar-vertical">
            <div className="simplebar-scrollbar"></div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Group;
