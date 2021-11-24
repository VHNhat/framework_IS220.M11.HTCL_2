import Fade from '@mui/material/Grow';
import Pagination from '@mui/material/Pagination';
import Paper from '@mui/material/Paper';
import Stack from '@mui/material/Stack';
import PropTypes from 'prop-types';
import React from 'react';
import '../stylesTable.scss';
TableAccount.propTypes = {
  List: PropTypes.array,
  ListTitleHead: PropTypes.array,
};
TableAccount.defaultProps = {
  List: [],
  ListTitleHead: [],
};
export default function TableAccount(props) {
  const HandleDelete = async (id) => {
    if (window.confirm('Bạn đã chắc chắn muốn xóa?')) {
      await document.getElementById(`${id}`).remove();
    }
  };
  const { List, ListTitleHead, paginate, setPaginate } = props;
  function changePage(page) {
    setPaginate({
      ...paginate,
      page: page,
    });
  }
  return (
    <>
      <Stack className='mt-4' spacing={2}>
        <Pagination
          count={paginate?.count}
          color="primary"
          onChange={(e, value) => changePage(value)}
        />
      </Stack>
      <Fade direction='up' in={true} timeout={400} className='body_page'>
        <Paper>
          <div>
            <table className='itemTable'>
              <thead className='headerTable'>
                <tr>
                  <th>STT</th>
                  {ListTitleHead.map((item, index) => (
                    <th key={index}>{item.Name}</th>
                  ))}
                </tr>
              </thead>
              <tbody>
                {List.map((item, index) => (
                  <tr key={index} id={item.id}>
                    <td>{index + 1}</td>
                    <td>{item.id}</td>
                    <td className='text_over'>{item.name}</td>
                    <td className='text_over'>{item.gmail}</td>
                    <td className='text_over'>{item.phone}</td>
                    <td>
                      <button
                        type='button'
                        className='btn btn-outline-danger'
                        data-set={item.id}
                        onClick={() => HandleDelete(item.id)}>
                        Xóa
                      </button>
                    </td>
                    <td>
                      <button
                        type='button'
                        className='btn btn-outline-success'
                        data-set={item.id}>
                        Cập nhật
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </Paper>
      </Fade>
    </>
  );
}