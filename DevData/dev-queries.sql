--SELECT * FROM USER_TABLE WHERE USER_NAME = 'User 1' AND PASSWORD = 'password'

select b.big_code, m.* from big_kind b 
inner join medium_kind m on b.big_code = m.big_code
