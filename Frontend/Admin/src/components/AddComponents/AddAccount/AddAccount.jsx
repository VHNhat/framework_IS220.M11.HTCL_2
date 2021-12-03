/* eslint-disable jsx-a11y/alt-text */
import Fade from '@mui/material/Grow';
import Paper from '@mui/material/Paper';
import { useSnackbar } from 'notistack';
import React, { useContext, useState } from 'react';
import './styles.scss';
import { context } from './../../../app/Context';
import Account from './../../Account/index';
function AddAccount(props) {
  const Context = useContext(context);
  const { setBodyAdmin, setFillerAdmin } = Context;
  const { enqueueSnackbar } = useSnackbar();
  const [valueData, setValueData] = useState({
    Username: '',
    Password: '',
    Role: '',
  });
  const handleChangeData = (event) => {
    setValueData({
      ...valueData,
      [event.target.name]: [event.target.value].toString(),
    });
  };
  const HandleUpload = () => {
    enqueueSnackbar('Tải lên thành công', { variant: 'success' });
  };
  function Prev() {
    setBodyAdmin(<Account />);
    setFillerAdmin('ACCOUNT');
  }
  return (
    <div className='AddAccount'>
      <Fade in={true} timeout={200} style={{ height: '100%' }}>
        <Paper>
          <button
            type='button'
            className='btn btn-success d-flex gap-2'
            style={{ position: 'absolute' }}
            onClick={() => Prev()}>
            <i
              style={{ fontSize: '1.5rem' }}
              className='fad fa-chevron-circle-left'></i>
            <p className> Quay lại</p>
          </button>
          <h2 className='text-center pt-4'>Tạo tài khoản mới</h2>

          <div className='dataAdd'>
            <div className='form-floating mb-3 inputData'>
              <input
                type='text'
                className='form-control '
                name='Username'
                color='warning'
                value={valueData?.Username}
                onChange={handleChangeData}
              />
              <label htmlFor='floatingInput'>Username</label>
            </div>

            <div className='form-floating mb-3 inputData'>
              <input
                type='date'
                className='form-control'
                name='Password'
                color='warning'
                value={valueData?.Password}
                onChange={handleChangeData}
              />

              <label htmlFor='floatingInput'>Password</label>
            </div>
            <div className='form-floating mb-3 inputData'>
              <select
                type='text'
                className='form-control '
                name='Role'
                color='warning'
                value={valueData?.Role}
                onChange={handleChangeData}>
                <option value='1'>1</option>
                <option value='2'>2</option>
                <option value='3'>3</option>
              </select>

              <label htmlFor='floatingInput'>Role</label>
            </div>

            <div className='inputData'>
              <button
                type='submit'
                className='btn btn-success inputData'
                style={{ width: '100%', margin: '0 auto' }}
                onClick={HandleUpload}>
             Tạo tài khoản
              </button>
            </div>
          </div>
        </Paper>
      </Fade>
    </div>
  );
}

export default AddAccount;