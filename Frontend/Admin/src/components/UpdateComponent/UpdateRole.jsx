/* eslint-disable jsx-a11y/alt-text */
import Fade from '@mui/material/Grow';
import Paper from '@mui/material/Paper';
import { useSnackbar } from 'notistack';
import React, { useContext, useState } from 'react';
import { context } from '../../app/Context';
import './stylesUpdateComponent/UpdateRole.scss';
import Role from './../Role/index';
function UpdateRole(props) {
  const Context = useContext(context);
  const { id } = props; 
  const { setBodyAdmin, setFillerAdmin,TypeDataPro } = Context;
  const { enqueueSnackbar } = useSnackbar();
  const [valueData, setValueData] = useState({
    Id:id,
    RoleName: '',
    Description: '',
 
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
    setBodyAdmin(<Role />);
    setFillerAdmin('ROLE');
  }
  return (
    <div className='UpdateRole'>
      <Fade in={true} timeout={200} style={{ height: '100%' }}>
        
        <Paper>
        <button
           style={{width:'fit-content',position:'absolute'}}
            type='button'
            className='btn btn-success d-flex gap-2'
            onClick={() => Prev()}>
            <i
              style={{ fontSize: '1.5rem' }}
              className='fad fa-chevron-circle-left'></i>
            <p className> Quay lại</p>
          </button>
          <h2 className='text-center pt-4'>Cập nhật quyền </h2>
          <p  style={{width:'50%',margin:'0 auto'}}>Mã quyền:{id}</p>
          <div className='dataAdd'>
            <div className='form-floating mb-3 inputData'>
              <input
                type='text'
                className='form-control '
                name='RoleName'
                color='warning'
                value={valueData?.RoleName}
                onChange={handleChangeData}
              />
              <label htmlFor='floatingInput'>Tên Quyền</label>
            </div>

            <div className='form-floating mb-3 inputData'>
              <input
                type='text'
                className='form-control'
                name='Description'
                color='warning'
                value={valueData?.Description}
                onChange={handleChangeData}
              />

              <label htmlFor='floatingInput'>Mô tả </label>
            </div>
           
            <div className='inputData'>
              <button
                type='submit'
                className='btn btn-success inputData'
                style={{ width: '100%', margin: '0 auto' }}
                onClick={HandleUpload}>
                Cập nhật 
              </button>
            </div>
          </div>
        </Paper>
      </Fade>
    </div>
  );
}

export default UpdateRole;
