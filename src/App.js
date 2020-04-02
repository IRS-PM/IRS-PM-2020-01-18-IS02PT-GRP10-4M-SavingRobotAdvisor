import React from 'react';
import AppBar from '@material-ui/core/AppBar';
import CssBaseline from '@material-ui/core/CssBaseline';
import Drawer from '@material-ui/core/Drawer';
import Hidden from '@material-ui/core/Hidden';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import {makeStyles, useTheme} from '@material-ui/core/styles';
import TextField from "@material-ui/core/TextField";
import InputAdornment from "@material-ui/core/InputAdornment";
import {AccountBalance, CreditCard, Launch, MonetizationOn} from "@material-ui/icons";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Link from "@material-ui/core/Link";
import Tooltip from "@material-ui/core/Tooltip";

const drawerWidth = 275;

const useStyles = makeStyles(theme => ({
    root: {
        display: 'flex',
        marginBottom:10,
    },
    drawer: {
        [theme.breakpoints.up('sm')]: {
            width: drawerWidth,
            flexShrink: 0,
        },

    },
    appBar: {
        [theme.breakpoints.up('sm')]: {
            width: `calc(100% - ${drawerWidth}px)`,
            marginLeft: drawerWidth,
        },
    },
    menuButton: {
        marginRight: theme.spacing(2),
        [theme.breakpoints.up('sm')]: {
            display: 'none',
        },
    },
    toolbar: theme.mixins.toolbar,
    drawerPaper: {
        width: drawerWidth,
    },
    content: {
        flexGrow: 1,
        padding: theme.spacing(3),
    },

    bullet: {
        display: 'inline-block',
        margin: '0 2px',
        transform: 'scale(0.8)',
    },
    title: {
        fontSize: 16,
        fontWeight: 'bold',
        textDecorationLine: 'underline',
    },
    pos: {
        fontSize: 11,
        marginBottom: 14,
    },
}));

const initialList = [];

let accountInfo = [];
accountInfo["CitiMaxiGain"]={"name":"Citi MaxiGain","url":"https://www.citibank.com.sg/gcb/deposits/mxgn-savacc.htm"};
accountInfo["OCBC360"]={"name":"OCBC 360","url":"https://www.ocbc.com/personal-banking/accounts/360-account.html"};
accountInfo["MaybankSaveUp"]={"name":"Maybank SaveUp","url":"https://www.maybank2u.com.sg/en/personal/saveup/save-up-programme.page"};
accountInfo["CIMBFastSaver"]={"name":"CIMB FastSaver","url":"https://www.cimbbank.com.sg/en/personal/products/accounts/savings-accounts/cimb-fastsaver-account.html"};
accountInfo["SCBonusSaver"]={"name":"SC Bonus$aver","url":"https://www.sc.com/sg/save/current-accounts/bonussaver/"};
accountInfo["Multiplier"]={"name":"DBS Multiplier","url":"https://www.dbs.com.sg/personal/deposits/bank-earn/multiplier"};
accountInfo["UOBONE"]={"name":"UOB ONE","url":"https://www.uob.com.sg/personal/save/chequeing/one-account.page"};
accountInfo["BOCSmartSaver"]={"name":"BOC SmartSaver","url":"https://www.bankofchina.com/sg/pbservice/pb1/201611/t20161130_8271280.html"};

let cardInfo = [];
cardInfo["CitiCashback"]={"name":"Citi Cashback","url":"https://www.citibank.com.sg/gcb/credit_cards/dividend-card.htm"};
cardInfo["OCBC365"]={"name":"OCBC 365","url":"https://www.ocbc.com/personal-banking/cards/365-cashback-credit-card"};
cardInfo["MaybankFamilyAndFriends"]={"name":"Maybank Family And Friends","url":"https://www.maybank2u.com.sg/en/personal/cards/credit/maybank-family-and-friends-mastercard.page"};
cardInfo["CIMBSignature"]={"name":"CIMB Signature","url":"https://www.cimbbank.com.sg/en/personal/products/cards/credit-cards/cimb-visa-signature.html"};
cardInfo["SCUnlimitedCashback"]={"name":"SC Unlimited Cashback","url":"https://www.sc.com/sg/credit-cards/unlimited-cashback-credit-card/"};
cardInfo["POSBEveryday"]={"name":"POSB Everyday","url":"https://www.posb.com.sg/personal/cards/credit-cards/posb-everyday-card"};
cardInfo["UOBONE"]={"name":"UOB ONE","url":"https://www.uob.com.sg/personal/cards/credit/one/"};
cardInfo["BOCFamily"]={"name":"BOC Family","url":"https://www.bankofchina.com/sg/bcservice/bc1/201605/t20160503_6891836.html"};

function processResult(row) {
    if (cardInfo[row.card]) {
        row.cardName = cardInfo[row.card].name;
        row.cardUrl = cardInfo[row.card].url;
    }

    if (accountInfo[row.account]) {
        row.accountName = accountInfo[row.account].name;
        row.accountUrl = accountInfo[row.account].url;
    }

    return row
}

export function SimpleCard(props) {
    const classes = useStyles();

    return (
        <Card className={classes.root}>

            <CardContent>
                <img alt={props.image} src={process.env.PUBLIC_URL + props.image + '.png'} />
            </CardContent>
            <CardContent>
                <Typography className={classes.title} color="textPrimary" gutterBottom>
                    Bank: {props.bank}
                </Typography>
                <Typography variant="body2" component="p">
                    Bank account: {props.accountName} <Tooltip title={"Open " + props.accountName + " website"}><Link target="_blank" href={props.accountUrl}><Launch fontSize="inherit"/></Link></Tooltip><br/>
                    Credit card:  {props.cardName} <Tooltip title={"Open " + props.cardName + " website"}><Link target="_blank" href={props.cardUrl}><Launch fontSize="inherit"/></Link></Tooltip><br/><br/>
                </Typography>
                <Typography variant="h7" component="h4">
                    Annual Value: ${props.combined.toFixed(2)}<br/>
                    Savings interest: ${props.interest.toFixed(2)} ({props.interest_rate.toFixed(2)}%)<br/>
                    Credit cashback: ${props.cashback.toFixed(2)} ({props.cashback_rate.toFixed(2)}%)<br/>
                </Typography>
                <Typography className={classes.pos} color="textSecondary">
                    * Effective interest/cashback rate in brackets
                </Typography>
            </CardContent>
            <CardActions>

            </CardActions>

        </Card>
    );
}

function ResponsiveDrawer(props) {
    const [income, setIncome] = React.useState('');
    const [expense, setExpense] = React.useState('');
    const [savings, setSavings] = React.useState('');
    const [results, setResults] = React.useState(initialList);
    const [incomeError, setIncomeError] = React.useState('');
    const [expenseError, setExpenseError] = React.useState('');
    const [savingsError, setSavingsError] = React.useState('');

    const {container} = props;
    const classes = useStyles();
    const theme = useTheme();
    const [mobileOpen, setMobileOpen] = React.useState(false);

    const handleDrawerToggle = () => {
        setMobileOpen(!mobileOpen);
    };

    const handleIncomeChange = event => {
        if (event.target.value.length > 0 && event.target.value >= 0) {
            setIncomeError("");
        } else {
            setIncomeError("true");
        }
        setIncome(event.target.value);
    };
    const handleExpenseChange = event => {
        if (event.target.value.length > 0 && event.target.value >= 0) {
            setExpenseError("");
        } else {
            setExpenseError("true");
        }
        setExpense(event.target.value);
    };
    const handleSavingsChange = event => {
        if (event.target.value.length > 0 && event.target.value >= 0) {
            setSavingsError("");
        } else {
            setSavingsError("true");
        }
        setSavings(event.target.value);
    };
    const compareButtonClick = event => {
        if (income && expense && savings && income >= 0 && expense >= 0 && savings >= 0) {
            fetch('http://localhost:5000/api/SavingRobotAdvisor/?income='+income+'&balance='+savings+'&spending='+expense)
                .then(res => res.json())
                .then((data) => {
                    data.sort((a, b) => (a.interest + a.rebate > b.interest + b.rebate) ? -1 : 1);
                    const results = data.map(processResult);
                    console.log(results);
                    setResults(results);
                })
                .catch(console.log);
        } else {
            if (!income) {
                setIncomeError("true");
            }
            if (!expense) {
                setExpenseError("true");
            }
            if (!savings) {
                setSavingsError("true");
            }
        }

        event.preventDefault();
    };

    const drawer = (

        <form className={classes.form} onSubmit={compareButtonClick} autoComplete="off">
            <Grid
                container
                spacing={16}
                direction="column"
                alignItems="center"
                justify="center"
                className={classes.container}
            >
                <Grid item xs={12}>
                    <TextField
                        required
                        id="income"
                        label="Monthly net income"
                        margin={"normal"}
                        variant="outlined"
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <MonetizationOn/>
                                </InputAdornment>
                            ),
                        }}
                        error={incomeError}
                        value={income}
                        onChange={handleIncomeChange}
                    />
                </Grid>
                <Grid item xs={12}>
                    <TextField
                        required
                        id="expenses"
                        label="Monthly credit card expenses"
                        margin={"normal"}
                        variant="outlined"
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <CreditCard/>
                                </InputAdornment>
                            ),
                        }}
                        error={expenseError}
                        value={expense}
                        onChange={handleExpenseChange}
                    />
                </Grid>
                <Grid item xs={12}>
                    <TextField
                        required
                        id="savings"
                        label="Cash Savings"
                        margin={"normal"}
                        variant="outlined"
                        InputProps={{
                            startAdornment: (
                                <InputAdornment position="start">
                                    <AccountBalance/>
                                </InputAdornment>
                            ),
                        }}
                        error={savingsError}
                        value={savings}
                        onChange={handleSavingsChange}
                    />
                </Grid>
                <Grid item xs={12}>
                    <Button onClick={compareButtonClick} variant="contained" color="primary">
                        Compare Banks
                    </Button>
                </Grid>
            </Grid>
        </form>

    );

    return (
        <div className={classes.root}>
            <CssBaseline/>
            <AppBar position="fixed" className={classes.appBar}>
                <Toolbar>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        edge="start"
                        onClick={handleDrawerToggle}
                        className={classes.menuButton}
                    >
                        <MenuIcon/>
                    </IconButton>
                    <Typography variant="h6" noWrap>
                        Savings Robot Advisor
                    </Typography>
                </Toolbar>
            </AppBar>
            <nav className={classes.drawer} aria-label="mailbox folders">
                {/* The implementation can be swapped with js to avoid SEO duplication of links. */}
                <Hidden smUp implementation="css">
                    <Drawer
                        container={container}
                        variant="temporary"
                        anchor={theme.direction === 'rtl' ? 'right' : 'left'}
                        open={mobileOpen}
                        onClose={handleDrawerToggle}
                        classes={{
                            paper: classes.drawerPaper,
                        }}
                        ModalProps={{
                            keepMounted: true, // Better open performance on mobile.
                        }}
                    >
                        {drawer}
                    </Drawer>
                </Hidden>
                <Hidden xsDown implementation="css">
                    <Drawer
                        classes={{
                            paper: classes.drawerPaper,
                        }}
                        variant="permanent"
                        open
                    >
                        {drawer}
                    </Drawer>
                </Hidden>
            </nav>
            <main className={classes.content}>
                <div className={classes.toolbar}/>
                <Typography paragraph>
                    Our robot advisor will help you pick the savings account and credit card with the
                    <ul>
                        <li>Highest annual interest on your savings</li>
                        <li>Best credit card rebate</li>
                    </ul>
                    You just need to state in the left column your:
                    <ul>
                        <li>Monthly net salary</li>
                        <li>Monthly credit card expenses</li>
                        <li>Current cash savings</li>
                    </ul>
                </Typography>


                    {results.map(item => (

                            <SimpleCard bank={item.bank}
                                        accountName={item.accountName}
                                        accountUrl={item.accountUrl}
                                        cardName={item.cardName}
                                        cardUrl={item.cardUrl}
                                        image={item.card}
                                        combined={item.interest + item.rebate}
                                        interest={item.interest}
                                        interest_rate={item.interest_rate}
                                        cashback={item.rebate}
                                        cashback_rate={item.rebate_rate}
                            />

                    ))}


            </main>
        </div>
    );
}

export default ResponsiveDrawer;
