import React from "react";
import avatar  from "assets/images/users/avatar-2.jpg";

const Message=()=>{
    return (
        <div className="tab-pane fade show active" id="pills-chat" role="tabpanel" aria-labelledby="pills-chat-tab">
          <div>
            <div className="px-4 pt-4">
              <h4 className="mb-4">Message</h4>
              <div className="search-box chat-search-box">
                <div className="input-group mb-3 bg-light  input-group-lg rounded-lg">
                  <div className="input-group-prepend">
                    <button className="btn btn-link text-muted pr-1 text-decoration-none" type="button">
                      <i className="ri-search-line search-icon font-size-18"></i>
                    </button>
                  </div>
                  <input type="text" className="form-control bg-light" placeholder="Search messages or users"/>
                </div>
              </div>
              </div>
            <div className="px-2">
              <h5 className="mb-3 px-3 font-size-16">Recent</h5>

              <div className="chat-message-list" data-simplebar="init">
                <div className="simplebar-wrapper">
                  <div className="simplebar-height-auto-observer-wrapper">
                    <div className="simplebar-height-auto-observer"></div>
                  </div>
                  <div className="simplebar-mask">
                    <div className="simplebar-offset">
                      <div className="simplebar-content-wrapper">
                        <div className="simplebar-content" style={{padding: 0}}>

                          <ul className="list-unstyled chat-list chat-user-list">
                            <li>
                              <a href="#">
                                <div className="media">

                                  <div className="chat-user-img online align-self-center mr-3">
                                    <img src={avatar} className="rounded-circle avatar-xs"
                                         alt=""/>
                                      <span className="user-status"></span>
                                  </div>

                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Patrick Hendricks</h5>
                                    <p className="chat-user-message text-truncate mb-0">Hey! there I'm available</p>
                                  </div>
                                  <div className="font-size-11">05 min</div>
                                </div>
                              </a>
                            </li>

                            <li className="unread">
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img away align-self-center mr-3">
                                    <img src={avatar} className="rounded-circle avatar-xs"
                                         alt=""/>
                                      <span className="user-status"></span>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Mark Messer</h5>
                                    <p className="chat-user-message text-truncate mb-0"><i
                                      className="ri-image-fill align-middle mr-1"></i> Images</p>
                                  </div>
                                  <div className="font-size-11">12 min</div>

                                  <div className="unread-message">
                                    <span className="badge badge-soft-danger badge-pill">02</span>
                                  </div>
                                </div>
                              </a>
                            </li>

                            <li>
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img align-self-center mr-3">
                                    <div className="avatar-xs">
                                                            <span
                                                              className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                                G
                                                            </span>
                                    </div>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">General</h5>
                                    <p className="chat-user-message text-truncate mb-0">This theme is awesome!</p>
                                  </div>
                                  <div className="font-size-11">20 min</div>
                                </div>
                              </a>
                            </li>

                            <li className="active">
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img online align-self-center mr-3">
                                    <img src={avatar} className="rounded-circle avatar-xs"
                                         alt=""/>
                                      <span className="user-status"></span>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Doris Brown</h5>
                                    <p className="chat-user-message text-truncate mb-0">Nice to meet you</p>
                                  </div>
                                  <div className="font-size-11">10:12 AM</div>

                                </div>
                              </a>
                            </li>
                            <li className="unread">
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img align-self-center mr-3">
                                    <div className="avatar-xs">
                                                            <span
                                                              className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                                D
                                                            </span>
                                    </div>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Designer</h5>
                                    <p className="chat-user-message text-truncate mb-0">Next meeting tomorrow
                                      10.00AM</p>
                                  </div>
                                  <div className="font-size-11">12:01 PM</div>
                                  <div className="unread-message">
                                    <span className="badge badge-soft-danger badge-pill">01</span>
                                  </div>
                                </div>
                              </a>
                            </li>
                            <li>
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img away align-self-center mr-3">
                                    <img src={avatar} className="rounded-circle avatar-xs"
                                         alt=""/>
                                      <span className="user-status"></span>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Steve Walker</h5>
                                    <p className="chat-user-message text-truncate mb-0"><i
                                      className="ri-file-text-fill align-middle mr-1"></i> Admin-A.zip</p>
                                  </div>
                                  <div className="font-size-11">03:20 PM</div>

                                </div>
                              </a>
                            </li>
                            <li className="typing">
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img align-self-center online mr-3">
                                    <div className="avatar-xs">
                                                            <span
                                                              className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                                A
                                                            </span>
                                    </div>
                                    <span className="user-status"></span>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Albert Rodarte</h5>
                                    <p className="chat-user-message text-truncate mb-0">typing<span
                                      className="animate-typing">
                                                            <span className="dot"></span>
                                                            <span className="dot"></span>
                                                            <span className="dot"></span>
                                                        </span></p>
                                  </div>
                                  <div className="font-size-11">04:56 PM</div>
                                </div>
                              </a>
                            </li>

                            <li>
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img align-self-center online mr-3">
                                    <div className="avatar-xs">
                                                            <span
                                                              className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                                M
                                                            </span>
                                    </div>
                                    <span className="user-status"></span>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Mirta George</h5>
                                    <p className="chat-user-message text-truncate mb-0">Yeah everything is fine</p>
                                  </div>
                                  <div className="font-size-11">12/07</div>

                                </div>
                              </a>
                            </li>
                            <li>
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img away align-self-center mr-3">
                                    <img src={avatar} className="rounded-circle avatar-xs"
                                         alt=""/>
                                      <span className="user-status"></span>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Paul Haynes</h5>
                                    <p className="chat-user-message text-truncate mb-0">Good morning</p>
                                  </div>
                                  <div className="font-size-11">12/07</div>

                                </div>
                              </a>
                            </li>
                            <li>
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img align-self-center online mr-3">
                                    <div className="avatar-xs">
                                                            <span
                                                              className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                                J
                                                            </span>
                                    </div>
                                    <span className="user-status"></span>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Jonathan Miller</h5>
                                    <p className="chat-user-message text-truncate mb-0">Hi, How are you?</p>
                                  </div>
                                  <div className="font-size-11">12/07</div>

                                </div>
                              </a>
                            </li>
                            <li>
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img away align-self-center mr-3">
                                    <img src={avatar} className="rounded-circle avatar-xs"
                                         alt=""/>
                                      <span className="user-status"></span>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Ossie Wilson</h5>
                                    <p className="chat-user-message text-truncate mb-0">I've finished it! See you so</p>
                                  </div>
                                  <div className="font-size-11">11/07</div>

                                </div>
                              </a>
                            </li>
                            <li>
                              <a href="#">
                                <div className="media">
                                  <div className="chat-user-img align-self-center online mr-3">
                                    <div className="avatar-xs">
                                                            <span
                                                              className="avatar-title rounded-circle bg-soft-primary text-primary">
                                                                S
                                                            </span>
                                    </div>
                                    <span className="user-status"></span>
                                  </div>
                                  <div className="media-body overflow-hidden">
                                    <h5 className="text-truncate font-size-15 mb-1">Sara Muller</h5>
                                    <p className="chat-user-message text-truncate mb-0">Wow that's great</p>
                                  </div>
                                  <div className="font-size-11">11/07</div>

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
         </div>)
};



export default Message;
